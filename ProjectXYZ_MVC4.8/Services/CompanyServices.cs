using ProjectXYZ_MVC4._8.Contracts;
using ProjectXYZ_MVC4._8.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectXYZ_MVC4._8.Services
{
    public class CompanyServices
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyServices(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

        }

        public IEnumerable<Company> GetCompany()
        {
            var company = _companyRepository.GetAll();
            if (!company.Any())
            {
                return null; // No Company found
            }

            var toDto = company.Select(companyEntity =>
                                                new Company
                                                {
                                                    ID = companyEntity.ID,
                                                    CompanyName = companyEntity.CompanyName,
                                                    CompanyEmail = companyEntity.CompanyEmail,
                                                    CompanyPhoneNumber = companyEntity.CompanyPhoneNumber,
                                                    CompanyPhoto = companyEntity.CompanyPhoto,
                                                    ApprovalStatus = companyEntity.ApprovalStatus,

                                                }).ToList();

            return toDto; // Company found
        }

        public Company GetCompanyID(int id)
        {
            var company = _companyRepository.GetById(id);
            if (company is null)
            {
                return null; // company not found
            }

            var toDto = new Company
            {
                ID = company.ID,
                CompanyName = company.CompanyName,
                CompanyEmail = company.CompanyEmail,
                CompanyPhoneNumber = company.CompanyPhoneNumber,
                CompanyPhoto = company.CompanyPhoto,
                ApprovalStatus = company.ApprovalStatus,
            };

            return toDto; // company found
        }


        public Company CreateCompany(Company newCompany, HttpPostedFileBase companyPhoto)
        {
            try
            {
                var company = new Company
                {
                    CompanyName = newCompany.CompanyName,
                    CompanyEmail = newCompany.CompanyEmail,
                    CompanyPhoneNumber = newCompany.CompanyPhoneNumber,
                    ApprovalStatus = "Pending",
                };

                // Handle file upload
                if (companyPhoto != null && companyPhoto.ContentLength > 0)
                {
                    using (var binaryReader = new BinaryReader(companyPhoto.InputStream))
                    {
                        company.CompanyPhoto = binaryReader.ReadBytes(companyPhoto.ContentLength);
                    }
                }

                var createdCompany = _companyRepository.Create(company);
                if (createdCompany is null)
                {
                    return null; // Company not created
                }

                return createdCompany; // Company created
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return null; // Return null or throw a custom exception based on your error-handling strategy
            }
        }

        public int UpdateCompany(Company updateCompany)
        {
            var isExist = _companyRepository.IsExist(updateCompany.ID);
            if (!isExist)
            {
                return -1; // Company Not Found
            }

            var getCompany = _companyRepository.GetById(updateCompany.ID);

            var company = new Company
            {
                CompanyName = updateCompany.CompanyName,
                CompanyEmail = updateCompany.CompanyEmail,
                CompanyPhoneNumber = updateCompany.CompanyPhoneNumber,
                CompanyPhoto = updateCompany.CompanyPhoto,
                ApprovalStatus = updateCompany.ApprovalStatus,
            };

            var isUpdate = _companyRepository.Update(company);
            if (!isUpdate)
            {
                return 0; // company not updated
            }

            return 1;
        }

        public int DeleteCompany(int id)
        {
            var isExist = _companyRepository.IsExist(id);
            if (!isExist)
            {
                return -1; // company not found
            }

            var company = _companyRepository.GetById(id);
            var isDelete = _companyRepository.Delete(company);
            if (!isDelete)
            {
                return 0; // company not deleted
            }

            return 1;
        }
    }
}