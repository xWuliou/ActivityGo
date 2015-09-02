using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActivityGo.DataService;
using ActivityGo.Models;
using MongoDB.Bson;

namespace ActivityGo.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserService userService;

        public UserController()
        {
            userService = new UserService();
        }
        [Route("create")]
        [HttpPost]
        //  [Authorize]
        public HttpResponseMessage CreateUser(HttpRequestMessage request, [FromBody] User user)
        {
            if (userService.RegisterUser(user).ID != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, user);
            }
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage UpdateUser(HttpRequestMessage request, [FromBody] User user)
        {
            if (userService.UpdateUser(user).ID != null)
            {
                return request.CreateResponse(HttpStatusCode.OK, user);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, user);
            }

        }

        [Route("get")]
        [HttpGet]
        public HttpResponseMessage GetUser(HttpRequestMessage request, [FromUri] string name)
        {
            var user = userService.GetUser(name);
            var user2 = userService.GetUserByName(name);
            if (user.ID != null)
            {
                return request.CreateResponse(HttpStatusCode.OK, user);
            }
            else if (user2.ID != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user2);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, user);
            }
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteUser(HttpRequestMessage request, [FromBody] User user)
        {
            var resultUser = userService.DeleteUser(user);
            if (resultUser.ID != null && resultUser.ValidStatus == 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, user);
            }
        }

        [Route("login")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, [FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "用户名或密码不能为空");
            }
            else
            {
                if (string.IsNullOrEmpty(userService.Login(user).ID))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "用户名或密码错误");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "登陆成功");
                }
            }
        }

      [Route("testget")]
      [HttpGet]
      public int Get()
      {
        return 200;
      }
    }
}
