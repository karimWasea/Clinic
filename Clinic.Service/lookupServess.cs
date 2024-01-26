using Clincic.DataAccesslayer;

using Clinic.Abstract;

using Clinicss.Models;

using Microsoft.AspNetCore.Mvc.Rendering;

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


        public List<SelectListItem> AvailableAppointments(Guid doctorId, int chosenDayOffset = 5)
        {
            var doctorExistingAppointments = new HashSet<DateTime>(
                _applicationDBcontext.Visits
                    .Where(da => da.Id == doctorId)
                    .Select(da => da.VisitsApientment));

            var availableSlots = new List<SelectListItem>();

            DateTime currentDate = DateTime.Now.Date;
            DateTime futureDate = currentDate.AddDays(7);
            DateTime startOfDay = futureDate.Date.AddHours(12); // Start time for appointments
            DateTime endOfDay = futureDate.Date.AddHours(12 + 23).AddMinutes(30 * 23); // End time for appointments


            while (currentDate <= futureDate)
            {
                //for (int i = 0; i < 24; i++)
                //{
                for (DateTime potentialTimeSlot = startOfDay; potentialTimeSlot <= endOfDay; potentialTimeSlot = potentialTimeSlot.AddMinutes(30))
                {

                    if (!IsTimeSlotBooked(doctorId, potentialTimeSlot))
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

                currentDate = currentDate.AddDays(1);
            }

            return availableSlots;
        }

        private bool IsTimeSlotBooked(Guid doctorId,     DateTime timeSlot)
        {
            return _applicationDBcontext.Visits
                .Any(da => da.Id == doctorId && da.VisitsApientment == timeSlot);
        }

    }
}
