using HRTrainingTracker.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.BusinessLayer
{
    public static class Ext
    {
        public static IList<SelectListItem> ShiftSelectList (this IOrderedQueryable<Shift> Shifts)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in Shifts)
            {
                selectList.Add(new SelectListItem { Value = item.ShiftID.ToString(), Text = item.Name });
            }

            return selectList;
        }

        public static IList<SelectListItem> DeptSelectList(this IOrderedQueryable<Department> Depts)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in Depts)
            {
                selectList.Add(new SelectListItem { Value = item.DepartmentID.ToString(), Text = item.Name });
            }

            return selectList;
        }

        public static IList<SelectListItem> BuildingSelectList(this IOrderedQueryable<Building> Depts)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in Depts)
            {
                selectList.Add(new SelectListItem { Value = item.BuildingID.ToString(), Text = item.Name });
            }

            return selectList;
        }
    }
}
