using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StaffManagementSystem.Web.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace StaffManagementSystem.Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;
        public StaffController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
        }

        public IActionResult Index()
        {
            return View();
        }

        #region update staff

        //This is also used to search for staff by emp_num
        public async Task<IActionResult> Update(string? emp_num)

        {

            //check if emp_num is not empty
            if (emp_num != null)
            {
                // get staff by emp num
                var staff = await GetStaffByEmp_numberAsync(emp_num);
                if (staff != null)
                {
                    //set flag to true and return staffvm obj
                    ViewData["recordfound"] = true;
                    return View(staff);

                }
                else
                {
                    //set flag to false and return empty vm
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
        public async Task<IActionResult> Update(Staff model)
        {
            string updatestatus = "";

            string apimethodURL = apiBaseUrl + "Staffs/UpdateStaff";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders
                          .Accept
                          .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                var myContent = JsonConvert.SerializeObject(model);
                var response = await httpClient.PostAsJsonAsync(apimethodURL, model);// pass model to be deleted

                if (response.IsSuccessStatusCode)
                {
                    //check if response is success
                    //set flag to true
                    //read response flag
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    updatestatus = response.IsSuccessStatusCode.ToString();
                }
                else
                {
                    //set update flag to error, detailed error handling can be done
                    updatestatus = "error";
                }

                
            }
            ViewData["updatestatus"] = updatestatus;
            return View(model);
        }
        #endregion

        #region helpers
        //method to get staff by emp num
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

                        staff = JsonConvert.DeserializeObject<Staff>(apiResponse); ;
                    }
                    else
                    {
                        return null;
                    }

                }
            }

            return staff;


        }
        #endregion
    }
}