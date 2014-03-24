using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BusinessObject.StuCourseBo;
using Domain.common;
using HuatongApply.Data;
using IService.IStudent;

namespace Service.StuCourse
{
	/*****************************************
	*
	*
	 * 
	 * 
	 * 选课关系服务类
	 * 
	 * add by ys on 2013-12-14
	 * 
	 * 
	 * 
	**************************/


	public class StudentService:IStudentService
	{
		/// <summary>
		/// 批量更新学生的所有选课
		/// </summary>
		/// <param name="studentBo"></param>
		/// <returns></returns>
		public bool UpdateStudentCourses(StudentBo studentBo)
		{
			bool result = false;
			if(studentBo.CourseListBos==null)
			{
				return result;
			}
			using (var context=new HuatongApplyContext())
			{
				List<Course> courses=new List<Course>();
				try
				{
					context.BeginTransaction();
					var tempStudent = context.Student.FirstOrDefault(p => p.Identification == studentBo.Identification);
					if (tempStudent != null && tempStudent.CourseList != null)
					{
						tempStudent.CourseList.Clear();
						context.SubmitChanges();
						foreach (var courseBo in studentBo.CourseListBos)
						{
							var tempAdd = context.Course.FirstOrDefault(p => p.Identification == courseBo.Identification);
							if (tempAdd != null)
							{
								courses.Add(tempAdd);
							}
						}
						tempStudent.CourseList = courses;
					}
					context.CommitTransaction();
					result = true;
				}
				catch (Exception e)
				{
					context.RollbackTransaction();
					result = false;
					LogHelper.WriteLog(string.Format("StudentService.UpdateStudentCourses({0})",studentBo),e);
				}
				return result;
			}
		}

		/// <summary>
		/// 删除学生的一门选课
		/// </summary>
		/// <param name="studentId"></param>
		/// <param name="courseId"></param>
		/// <returns></returns>
		public bool DeleteStudentCouse(int studentId, int courseId)
		{
			bool result = false;
			using (var context=new HuatongApplyContext())
			{
				try
				{
					context.BeginTransaction();
					var tempStudent = context.Student.FirstOrDefault(p => p.Identification == studentId);
					if (tempStudent != null)
					{
						#region 解除单个关系，正确写法
						/*var tempCourses = tempStudent.CourseList;
						var deleteEntity = tempCourses.FirstOrDefault(p => p.Identification == courseId);
						tempCourses.Remove(deleteEntity);
						#endregion

						#region 错误写法，这种写法不会解除关系
						/*var tempCourses = tempStudent.CourseList.ToList();
						tempCourses.RemoveAll(p => p.Identification == courseId);*/
						#endregion

						#region 解除全部关系
						tempStudent.CourseList.Clear();
						//tempStudent.CourseList.ToList().Clear();
						#endregion
					}
					context.CommitTransaction();
					result = true;
				}
				catch (Exception)
				{
					context.RollbackTransaction();
					result = false;
					//写入异常日志
				}
			}
			return result;
		}

		/// <summary>
		/// 删除学生的部分/所有选课
		/// </summary>
		/// <param name="studentId"></param>
		/// <param name="courseIds"></param>
		/// <returns></returns>
		public bool DeleteStudentCourses(int studentId, int[] courseIds)
		{
			bool result = false;
			using (var context = new HuatongApplyContext())
			{
				try
				{
					context.BeginTransaction();
					var tempStudent = context.Student.FirstOrDefault(p => p.Identification == studentId);
					/**
					 * tempStudent.CourseList.Clear();//删除所有选课直接clear即可
					context.CommitTransaction();**/
					if (tempStudent != null)
					{
						var tempCourses = tempStudent.CourseList.ToList();
						foreach (var courseId in courseIds)
						{
							var tempCourse=tempCourses.Find(p => p.Identification == courseId);
							if(tempCourse!=null)
							{
								tempCourses.Remove(tempCourse);
							}
						}
					}
					context.CommitTransaction();
					result = true;
				}
				catch (Exception)
				{
					context.RollbackTransaction();
					result = false;
					//写入异常日志
				}
				return result;
			}
		}

		/// <summary>
		/// 添加一个学生，并同时给他添加一些所选的课程
		/// </summary>
		/// <param name="studentBo"></param>
		/// <returns></returns>
		public bool AddStudent(StudentBo studentBo)
		{
			bool result = false;
			//准备学生数据
			Student entity=new Student();
			Mapper.Reset();
			Mapper.CreateMap<StudentBo, Student>();
			entity=Mapper.Map<StudentBo, Student>(studentBo);
			//准备课程数据
			List<Course>courses=new List<Course>();
			if (studentBo.CourseListBos != null)
			{
				courses=studentBo.CourseListBos.Select(p => new Course(){Identification= p.Identification}).ToList();
			}
			using (var context=new HuatongApplyContext())
			{
				try
				{
					context.BeginTransaction();
					entity.CourseList = courses;//关联起关系
					context.Student.InsertOnSubmit(entity);//写入学生
					context.CommitTransaction();
					result = true;
				}
				catch (Exception e)
				{
					context.RollbackTransaction();
					result = false;
					//异常日志写入
				}
			}
			return result;
		}
	}
}
