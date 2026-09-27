using Hospital.DAL.Models;
using Hospital.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Repository.Implementation
{
    public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
    {
        public DoctorRepo(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
