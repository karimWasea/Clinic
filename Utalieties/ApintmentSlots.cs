using Clincic.DataAccesslayer;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utalieties
{
    public   class ApintmentSlots
    {

        private readonly ApplicationDBcontext _applicationDBcontext;

        public ApintmentSlots(ApplicationDBcontext _applicationDBcontext)
        {

            this._applicationDBcontext = _applicationDBcontext;


        }
        public   List<SelectListItem> AvailableAppointments(Guid doctorId)
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
    }
}
