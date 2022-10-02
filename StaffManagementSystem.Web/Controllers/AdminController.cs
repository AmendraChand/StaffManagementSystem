using Microsoft.AspNetCore.Mvc;
using StaffManagementSystem.Web.Models;
using System.Diagnostics;

using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffManagementSystem.Web.Models.Mappers;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Http.Headers;

namespace StaffManagementSystem.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;
        public AdminController(ILogger<AdminController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
        }

        public IActionResult Index()
        {
            return View();
        }

        #region delete staff
        //This is also used to search for staff by emp_num
        public async Task<IActionResult> Delete(string? emp_num)
           
        {

            // check for empty emp_num 
            if (emp_num != null)
            {
                //get staff by empnum
                var staff = await GetStaffByEmp_numberAsync(emp_num);
                if(staff != null)
                {
                    //if staff object returned from API set flags to true and return staff obj
                    ViewData["recordfound"] = true;
                    return View(staff);

                }
                else
                {
                    // if not found set flag false and return empty view
                    ViewData["recordfound"] = false;
                    return View();
                }
            }
            else 
            { 
                return View(); 
            } 
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Staff model)
        {
            string deletestatus = "";

            using (var httpClient = new HttpClient())
            {
                string apimethodURL = apiBaseUrl + "Staffs/DeleteStaff/" + model.Id;//set API url for DeleteStaff to base URL
                using (var response = await httpClient.PostAsJsonAsync(apimethodURL, model.Id))// pass staff id to be deleted
                {
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)// check response if success
                    {
                        //read content and set flag to success
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        deletestatus = response.IsSuccessStatusCode.ToString();
                    }
                    else
                    {
                        //set flad to error, staff not found or internal server error, future proper implementation of error handling
                        deletestatus = "error";
                    }

                }
            }
            //return deleted status
            ViewData["deletestatus"] = deletestatus;
            return View();
        }
        #endregion

        #region create staff
        public async Task<IActionResult> Create()
        {
            //create viewmodel for staff
            StaffViewModel staff = new StaffViewModel();
            //populate dropdown list values from API
            staff.GenderDropDownList = await CreateGenderSelectListAsync();
            staff.QualificationDropDownList = await CreateQualificationSelectListAsync();

            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffViewModel model)
        {
            //populate drop down list from API
            model.GenderDropDownList = await CreateGenderSelectListAsync();
            model.QualificationDropDownList = await CreateQualificationSelectListAsync();

            //check model state
            if (!ModelState.IsValid)
            {
                //if any validations fail return to view
                return View(model);
            }

            else
            {
                //validate emp_num for duplicate value
                string Emp_numExists = await ValidateEmployeeNumberAsync(model.emp_number);
                //set flag for emp num
                ViewData["Emp_numExists"] = Emp_numExists;

                if (Emp_numExists.Equals("false"))
                {
                    // create staff object if emp num does not exist
                    StaffMapper mapper = new StaffMapper();
                    Staff staff = mapper.StaffViewModelToStaffModel(model);

                    string apimethodURL = apiBaseUrl + "Staffs/CreateStaff";
                    using (var httpClient = new HttpClient())
                    {
                        //save staff
                        httpClient.DefaultRequestHeaders
                                  .Accept
                                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                        var myContent = JsonConvert.SerializeObject(staff);
                        var response = await httpClient.PostAsJsonAsync(apimethodURL, staff);

                        if (response.IsSuccessStatusCode)
                        {
                            //if successfully saved read response and create staff object, can convert this to staff vm then pass to view
                            var responseString = await response.Content.ReadAsStringAsync();
                            staff = JsonConvert.DeserializeObject<Staff>(responseString);

                            //set flag to true
                            ViewData["StaffCreated"] = true;

                        }
                        else
                        {
                            //set flag to false if error in saving 
                            ViewData["StaffCreated"] = false;
                        }

                    }

                    return View(model);
                }
                else
                {
                    return View(model);
                }

            }
        }


        #endregion

        #region helper methods

        //method to get staff by employee numer
        public async Task<Staff> GetStaffByEmp_numberAsync(string? emp_number)
        {
            Staff staff = new Staff();

            using (var httpClient = new HttpClient())
            {
                string apimethodURL = apiBaseUrl + "Staffs/" + emp_number;//set API url for get staff by emp_number to base URL
                using (var response = await httpClient.GetAsync(apimethodURL))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        staff =JsonConvert.DeserializeObject<Staff>(apiResponse); ;
                    }
                    else
                    {
                        return null;
                    }
                    
                }
            }

            return staff;


        }
        //method to verify emp num
        public async Task<string> ValidateEmployeeNumberAsync(string emp_number)
        {
            string empnumexists = "";

            using (var httpClient = new HttpClient())
            {
                string apimethodURL = apiBaseUrl + "Staffs/EmpNumExists?emp_number=" + emp_number;//set API url for EmpNumExists to base URL
                using (var response = await httpClient.GetAsync(apimethodURL))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        empnumexists = apiResponse;
                    }
                    else
                    {
                        empnumexists = "Error";
                    }

                }
            }
            return empnumexists;
        }
        //method to create Gender select list for drop down
        public async Task<SelectList> CreateGenderSelectListAsync()
        {
            //get list of genders
            List<Gender> gender_list = new List<Gender>();

            using (var httpClient = new HttpClient())
            {
                string apimethodURL = apiBaseUrl + "Genders";//set API url for gender to base URL
                using (var response = await httpClient.GetAsync(apimethodURL))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        gender_list = JsonConvert.DeserializeObject<List<Gender>>(apiResponse);
                    }

                }
            }



            Gender gender = new Gender();
            gender.Id = 0;
            gender.description = "---- Select Gender ----";
            gender_list.Add(gender);

            IEnumerable<Gender> sortedEnum = gender_list.OrderBy(d => d.Id);
            IList<Gender> sortedGenders = sortedEnum.ToList();
            return new SelectList(sortedGenders, "Id", "description");

        }
        //method to create Qualification select list for drop down
        public async Task<SelectList> CreateQualificationSelectListAsync()
        {
            //get list of qualifications
            List<Qualification> qualification_list = new List<Qualification>();



            using (var httpClient = new HttpClient())
            {
                string apimethodURL = apiBaseUrl + "Qualifications";//set API url for Qualificaiton to base URL
                using (var response = await httpClient.GetAsync(apimethodURL))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        qualification_list = JsonConvert.DeserializeObject<List<Qualification>>(apiResponse);
                    }
                }
            }

            Qualification qualification = new Qualification();
            qualification.Id = 0;
            qualification.level = 0;
            qualification.description = "---- Select Qualification ----";
            qualification_list.Add(qualification);

            IEnumerable<Qualification> sortedEnum = qualification_list.OrderBy(d => d.Id);
            IList<Qualification> sortedQualifications = sortedEnum.ToList();
            return new SelectList(sortedQualifications, "Id", "description");

        }
        #endregion
    }
}