using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObject.StuCourseBo;

namespace IService.IStudent
{
	public interface IStudentService
	{
		/// <summary>
		/// 更新学生的所选课程
		/// add by ys on 2013-12-14
		/// </summary>
		/// <param name="studentBo"></param>
		/// <returns></returns>
		bool UpdateStudentCourses(StudentBo studentBo);

		/// <summary>
		/// 删除指定学生的一门所选课程
		/// add by ys on 2013-12-14
		/// </summary>
		/// <param name="courseId">要删除的课程id</param>
		/// <param name="studentId">学生id</param>>
		/// <returns></returns>
		bool DeleteStudentCouse(Int32 studentId,Int32 courseId);

		/// <summary>
		/// 删除指定学生的多门课程
		/// add by ys on 2013-12-14
		/// </summary>
		/// <param name="studentId"></param>
		/// <param name="courseIds">要删除的所选课程id集合</param>
		/// <returns></returns>
		bool DeleteStudentCourses(Int32 studentId, Int32[] courseIds);

		/// <summary>
		/// 新增一个学生
		/// </summary>
		/// <param name="studentBo"></param>
		/// <returns></returns>
		bool AddStudent(StudentBo studentBo);
	}
}
