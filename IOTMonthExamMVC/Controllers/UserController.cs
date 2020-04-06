using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IOTMonthExamMVC.Models;
using Newtonsoft.Json;

namespace IOTMonthExamMVC.Controllers
{
    public class UserController : Controller
    {
        HttpClientHelper client = new HttpClientHelper("http://localhost:58692/api/");
        /// <summary>
        /// 显示员工列表,查询
        /// </summary>
        /// <returns></returns>
        // GET: User
        public ActionResult Index()
        {
            string str = client.Get("User/Show");
            List<UserInfo> list = JsonConvert.DeserializeObject<List<UserInfo>>(str);
            return View(list);
        }
        /// <summary>
        /// 绑定部门下拉列表
        /// </summary>
        public void Bind()
        {
            string str = client.Get("User/GetBind");
            List<Depart> list = JsonConvert.DeserializeObject<List<Depart>>(str);
            ViewBag.list = new SelectList(list,"ID","Name");
        }
        /// <summary>
        /// 添加员工的显示界面
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public ActionResult AddUser()
        {
            Bind();
            return View();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public void AddUser(UserInfo m)
        {
            string str = client.Post("User/AddUser", JsonConvert.SerializeObject(m));
            int h = int.Parse(str);
            if(h>0)
            {
                Response.Write("<script>alert('添加成功');location.href='/User/Index'</script>");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Del(int id)
        {
            string str = client.Delete("User/DelUser/" + id);
            int h = int.Parse(str);
            if(h>0)
            {
                Response.Write("<script>alert('删除成功');location.href='/User/Index'</script>");
            }
        }
        /// <summary>
        /// 添加部门的显示界面
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public ActionResult AddDepart()
        {
            return View();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public void AddDepart(Depart m)
        {
            string str = client.Post("User/AddDepart", JsonConvert.SerializeObject(m));
            int h = int.Parse(str);
            if (h > 0)
            {
                Response.Write("<script>alert('添加成功');location.href='/User/Index'</script>");
            }
        }
        /// <summary>
        /// 查询员工
        /// </summary>
        /// <returns></returns>
        public ActionResult SelUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SelUser(string name,int id)
        {
            Bind();
            string str = client.Get("User/Show"+name+id);
            List<UserInfo> list = JsonConvert.DeserializeObject<List<UserInfo>>(str);
            return View(list);
        }
    }
}