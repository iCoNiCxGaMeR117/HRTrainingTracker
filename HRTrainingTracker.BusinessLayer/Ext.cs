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
        public static IList<SelectListItem> BuildSelectList (this IOrderedQueryable<Shift> Shifts)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in Shifts)
            {
                selectList.Add(new SelectListItem { Value = item.ShiftID.ToString(), Text = item.Name });
            }

            return selectList;
        }

        public static IList<SelectListItem> BuildSelectList(this IOrderedQueryable<Department> Depts)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in Depts)
            {
                selectList.Add(new SelectListItem { Value = item.DepartmentID.ToString(), Text = item.Name });
            }

            return selectList;
        }

        public static IList<SelectListItem> BuildSelectList(this IOrderedQueryable<Building> Depts)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in Depts)
            {
                selectList.Add(new SelectListItem { Value = item.BuildingID.ToString(), Text = item.Name });
            }

            return selectList;
        }

        public static IList<SelectListItem> BuildSelectList(this IOrderedQueryable<TrainingTypes> TrainingTypeList)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in TrainingTypeList)
            {
                selectList.Add(new SelectListItem { Value = item.TrainingTypesID.ToString(), Text = item.TrainingTypeName });
            }

            return selectList;
        }

        public static IList<SelectListItem> BuildSelectList(this IOrderedQueryable<Local> Localities)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in Localities)
            {
                selectList.Add(new SelectListItem { Value = item.LocalID.ToString(), Text = item.Name });
            }

            return selectList;
        }
    }
}
