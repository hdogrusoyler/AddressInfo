using AddressInfo.City.BusinessLogic.Abstract;
using AddressInfo.City.DataAccess.UnitOfWork.Abstract;
using AddressInfo.City.Entities.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace AddressInfo.City.BusinessLogic.Concrete
{
    public class CityManager : ICityService
    {
        private IUnitOfWork _unitOfWork;

        public CityManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RHand<Entities.Concrete.City> GetById(int Id)
        {
            var tr = new RHand<Entities.Concrete.City>();
            try
            {
                tr.Return = _unitOfWork.cityDal.Get(c => c.Id == Id);
            }
            catch (System.Exception Exp)
            {
                tr.isSuccess = false;
                tr.resultRemark = Exp.ToString();
            }
            return tr;
        }

        public ResHand<Entities.Concrete.City, ReturnType> GetAll()
        {
            var tr = new ResHand<Entities.Concrete.City, ReturnType>();
            try
            {
                int page = 1;
                int pageSize = 0;
                tr.ReturnList = _unitOfWork.cityDal.GetList(null, null, page, pageSize, (qry) => qry.OrderByDescending(x => x.Id));
            }
            catch (System.Exception Exp)
            {
                tr.isSuccess = false;
                tr.resultRemark = Exp.ToString();
            }
            return tr;
        }

        public void Add(Entities.Concrete.City entity)
        {
            System.IO.StringWriter writer = new System.IO.StringWriter();

            try
            {
                var option = new TransactionOptions();
                option.IsolationLevel = IsolationLevel.Serializable;
                option.Timeout = TimeSpan.FromMinutes(1);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    try
                    {
                        _unitOfWork.cityDal.Add(entity);
                        _unitOfWork.Save();
                    }
                    catch
                    {
                        throw;
                    }

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                writer.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
                Console.WriteLine(ex);
            }

            // Display messages.
            Console.WriteLine(writer.ToString());

            //_unitOfWork.resActionDal.Add(entity);
            //_unitOfWork.Save();
        }
        public void Update(Entities.Concrete.City entity)
        {
            System.IO.StringWriter writer = new System.IO.StringWriter();

            try
            {
                var option = new TransactionOptions();
                option.IsolationLevel = IsolationLevel.Serializable;
                option.Timeout = TimeSpan.FromMinutes(1);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    try
                    {

                        _unitOfWork.cityDal.Update(entity);
                        _unitOfWork.Save();
                    }
                    catch
                    {
                        throw;
                    }

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                writer.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
                Console.WriteLine(ex);
            }

            // Display messages.
            Console.WriteLine(writer.ToString());
        }

        public void Delete(Entities.Concrete.City entity)
        {
            System.IO.StringWriter writer = new System.IO.StringWriter();

            try
            {
                var option = new TransactionOptions();
                option.IsolationLevel = IsolationLevel.Serializable;
                option.Timeout = TimeSpan.FromMinutes(1);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    try
                    {


                        _unitOfWork.cityDal.Delete(entity);
                        _unitOfWork.Save();
                    }
                    catch
                    {
                        throw;
                    }

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                writer.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
                Console.WriteLine(ex);
            }

            // Display messages.
            Console.WriteLine(writer.ToString());
        }
    }
}
