using Clincic.DataAccesslayer;

using Clinic.Abstract;

using Clinicss.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Service
{
    public class lookupServess : IlookupServess
    {

        public readonly ApplicationDBcontext _applicationDBcontext;

        public lookupServess(ApplicationDBcontext _applicationDBcontext)
        {

            this._applicationDBcontext = _applicationDBcontext;


        }




        public List<SelectListItem> Gender()
        {
            return Enum.GetValues(typeof(Gender))
                                   .Cast<Gender>()
                                   .Select(hour => new SelectListItem
                                   {
                                       Value = ((int)hour).ToString(),
                                       Text = hour.ToString()
                                   })
                                   .ToList();
        }

        public IQueryable<SelectListItem>  AllCliniCs()
        {
            IQueryable<SelectListItem>? applicationuser = _applicationDBcontext.Clinic.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.clinicName
            }).OrderBy(c => c.Text).AsNoTracking();
            return applicationuser;
        }    
        
        public IQueryable<SelectListItem>  AllShifts()
        {
            IQueryable<SelectListItem>? applicationuser = _applicationDBcontext.SHifts.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).OrderBy(c => c.Text).AsNoTracking();
            return applicationuser;
        }
        public List<SelectListItem> AvailableAppointments(Guid doctorId)
        {
            var doctorExistingAppointments = new HashSet<DateTime>(_applicationDBcontext.Visits
                .Where(da => da.DoctorId == doctorId)
                .Select(da => da.VisitsApientment));
            var availableSlots = new List<SelectListItem>();

            DateTime currentDate = DateTime.Today.Date;
            DateTime futureDate = currentDate.AddDays(6); // Adjusted to 6 days

            while (currentDate <= futureDate)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Friday)
                {
                    for (int hour = 16; hour < 20; hour++) // Adjusted to loop from 4 PM to 7 PM
                    {
                        for (int minute = 0; minute < 60; minute += 30) // Loop for each 30-minute interval
                        {
                            DateTime potentialTimeSlot = currentDate.AddHours(hour).AddMinutes(minute);

                            if (!doctorExistingAppointments.Contains(potentialTimeSlot) &&
                                !IsTimeSlotBooked(doctorId, potentialTimeSlot))
                            {
                                if (potentialTimeSlot > DateTime.Now)
                                {
                                    availableSlots.Add(new SelectListItem
                                    {
                                        Value = potentialTimeSlot.ToString("yyyy-MM-dd HH:mm"),
                                        Text = potentialTimeSlot.ToString("yyyy-MM-dd hh:mm tt")
                                    });
                                }
                            }
                        }
                    }
                }

                currentDate = currentDate.AddDays(1);
            }

            return availableSlots;
        }

        private bool IsTimeSlotBooked(Guid doctorId, DateTime timeSlot)
        {
            return _applicationDBcontext.Visits
                .Any(da => da.Id == doctorId && da.VisitsApientment == timeSlot);
        }


        //public List<SelectListItem> AvailableAppointments(Guid doctorId, int chosenDayOffset = 5)
        //{
        //    var doctorExistingAppointments = new HashSet<DateTime>(
        //        _applicationDBcontext.Visits
        //            .Where(da => da.Id == doctorId)
        //            .Select(da => da.VisitsApientment));

        //    var availableSlots = new List<SelectListItem>();

        //    DateTime currentDate = DateTime.Now.Date.AddDays(chosenDayOffset); // Start from chosen day
        //    DateTime futureDate = currentDate.AddDays(6); // Adjusted for 6 days in a week
        //    DateTime startOfDay = currentDate.AddHours(4); // Start time for appointments
        //    DateTime endOfDay = currentDate.AddHours(20); // End time for appointments (8 PM)

        //    while (currentDate <= futureDate)
        //    {
        //        // Skip creating appointments for Fridays
        //        if (currentDate.DayOfWeek != DayOfWeek.Friday)
        //        {
        //            for (DateTime potentialTimeSlot = startOfDay; potentialTimeSlot < endOfDay; potentialTimeSlot = potentialTimeSlot.AddMinutes(30))
        //            {
        //                if (!IsTimeSlotBooked(doctorId, potentialTimeSlot) && potentialTimeSlot > DateTime.Now)
        //                {
        //                    availableSlots.Add(new SelectListItem
        //                    {
        //                        Value = potentialTimeSlot.ToString("yyyy-MM-dd HH:mm"),
        //                        Text = potentialTimeSlot.ToString("yyyy-MM-dd hh:mm tt")
        //                    });
        //                }
        //            }
        //        }

        //        currentDate = currentDate.AddDays(1);
        //        // Adjusted loop condition to handle 6 days in a week
        //        if (currentDate.DayOfWeek == DayOfWeek.Friday)
        //        {
        //            currentDate = currentDate.AddDays(1); // Skip Friday
        //        }
        //    }

        //    return availableSlots;
        //}

        //private bool IsTimeSlotBooked(Guid doctorId, DateTime timeSlot)
        //{
        //    return _applicationDBcontext.Visits
        //        .Any(da => da.Id == doctorId && da.VisitsApientment == timeSlot);
        //}

        public List<SelectListItem> VisitStutus()
        {
            return Enum.GetValues(typeof(Gender))
                                               .Cast<Visisttype>()
                                               .Select(hour => new SelectListItem
                                               {
                                                   Value = ((int)hour).ToString(),
                                                   Text = hour.ToString()
                                               })
                                               .ToList();
        }

        public List<SelectListItem> VisitType()
        {
            return Enum.GetValues(typeof(Gender))
                                               .Cast<VisitStatus>()
                                               .Select(hour => new SelectListItem
                                               {
                                                   Value = ((int)hour).ToString(),
                                                   Text = hour.ToString()
                                               })
                                               .ToList();
        }
    }
}
