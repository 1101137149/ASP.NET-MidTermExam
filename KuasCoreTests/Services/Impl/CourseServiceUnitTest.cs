﻿using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services
{
    [TestClass]
    public class CourseServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseService CourseService { get; set; }

        [TestMethod]
        public void TestCourseService_AddCourse()
        {
            Course course = new Course();
            course.Id = "UnitTests";
            course.Name = "單元測試";
            course.Description = 15;
            CourseService.AddCourse(course);

            Course dbCourse = CourseService.GetCourseById(course.Id);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.Id, dbCourse.Id);

            Console.WriteLine("員工編號為 = " + dbCourse.Id);
            Console.WriteLine("員工姓名為 = " + dbCourse.Name);
            Console.WriteLine("員工年齡為 = " + dbCourse.Description);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseById(course.Id);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseService_UpdateCourse()
        {
            // 取得資料
            Course course = CourseService.GetCourseById("dennis_yen");
            Assert.IsNotNull(course);

            // 更新資料
            course.Name = "單元測試";
            CourseService.UpdateCourse(course);

            // 再次取得資料
            Course dbCourse = CourseService.GetCourseById(course.Id);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.Name, dbCourse.Name);

            Console.WriteLine("員工編號為 = " + dbCourse.Id);
            Console.WriteLine("員工姓名為 = " + dbCourse.Name);
            Console.WriteLine("員工年齡為 = " + dbCourse.Description);

            Console.WriteLine("================================");

            // 將資料改回來
            course.Name = "嚴志和";
            EmployeeService.UpdateCourse(course);

            // 再次取得資料
            dbCourse = EmployeeService.GetCourseById(course.Id);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.Name, dbCourse.Name);

            Console.WriteLine("員工編號為 = " + dbCourse.Id);
            Console.WriteLine("員工姓名為 = " + dbCourse.Name);
            Console.WriteLine("員工年齡為 = " + dbCourse.Description);
        }


        [TestMethod]
        public void TestCourseService_DeleteCourse()
        {
            Course newCourse = new Course();
            newCourse.Id = "UnitTests";
            newCourse.Name = "單元測試";
            newCourse.Description = 15;
            CourseService.AddCourse(newCourse);

            Course dbCourse = CourseService.GetCourseById(newCourse.Id);
            Assert.IsNotNull(dbCourse);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseById(newCourse.Id);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseService_GetCourseById()
        {
            Course course = CourseService.GetCourseById("dennis_yen");
            Assert.IsNotNull(course);

            Console.WriteLine("員工編號為 = " + course.Id);
            Console.WriteLine("員工姓名為 = " + course.Name);
            Console.WriteLine("員工年齡為 = " + course.Description);
        }

    }
}
