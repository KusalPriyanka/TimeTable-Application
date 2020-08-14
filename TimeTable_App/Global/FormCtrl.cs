using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using TimeTable_App.Models;

/*
 *      Class Name      -   FormCtrl
 *      Author          -   Kusal Perera
 *      Date            -   14/08/2020
 *      Description     -   Handle the All CRUD functions of all forms 
 *      
 *      Version Control
 *          * [Kusal Perera]
 *              Implement the common class to handle the CRUD functions of all forms
 *      
 */

namespace TimeTable_App.Global
{
    public class FormCtrl
    {
        private TimeTableDbContext _dbContext;

        private TimeTableDbContext getDbContext() 
        {
            if (_dbContext == null) { _dbContext = new TimeTableDbContext(); }
            return _dbContext;
        }

        public ActionResult _saveFormData<T>(T saveObj) 
        {

            ActionResult ActionResult;

            try 
            {
                _dbContext = getDbContext();
                var _db = _dbContext.Set(saveObj.GetType());
                _db.Add(saveObj);
                _dbContext.SaveChanges();

                ActionResult = new ActionResult() { State = true, Data = saveObj };
            }
            catch (Exception ex) 
            {
                ActionResult = new ActionResult() { State = false, Data = ex.Message };
            }

            return ActionResult;
        }

        public ActionResult _updateFormData<T>(T saveObj) 
        {
            ActionResult ActionResult;

            _dbContext = getDbContext();

            try 
            {
                _dbContext.Entry(saveObj).State = EntityState.Modified;
                _dbContext.SaveChanges();
                ActionResult = new ActionResult() { State = true, Data = saveObj };
            }
            catch (Exception ex) 
            {
                ActionResult = new ActionResult() { State = false, Data = ex.Message };
            }

            return ActionResult;
        }

        public ActionResult _deleteFormData<T>(T saveObj)
        {
            ActionResult ActionResult;

            _dbContext = getDbContext();

            try
            {
                _dbContext.Entry(saveObj).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                ActionResult = new ActionResult() { State = true, Data = saveObj };
            }
            catch (Exception ex)
            {
                ActionResult = new ActionResult() { State = false, Data = ex.Message };
            }

            return ActionResult;
        }

        public ActionResult _getFormData(Type modelType, string Type) 
        {
            ActionResult ActionResult;

            try
            {
                _dbContext = getDbContext();
                Object modelObj = Activator.CreateInstance(modelType);
                MethodInfo methodInfo = modelType.GetMethod("GetFormData");
                dynamic result = methodInfo.Invoke(modelObj, new object[] { _dbContext , Type});
                ActionResult = new ActionResult() { State = true, Data = result };
            }
            catch (Exception ex)
            {
                ActionResult = new ActionResult() { State = false, Data = ex.Message };
            }

            return ActionResult;
        }
    }
}
