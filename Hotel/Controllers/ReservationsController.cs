using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Services;
using Hotel.DAL.Entities;

namespace Hotel.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationsService _reservationService;

        public ReservationsController()
        {
            _reservationService = new ReservationsService();
        }

        // GET: Reservations
        public async Task<ActionResult> Index()
        {
            var model = await _reservationService.GetAllAsync();
            return View(model);
        }

        // GET: Reservations/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var reservation = await _reservationService.GetByReservationIdAsync(id.Value);

            if (reservation == null)
            {
                return HttpNotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReservationId,MainGuestName,TotalAmount,Confirmed,FromDate,ToDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                await _reservationService.CreateReservationAsync(reservation);

                return RedirectToAction("Index");
            }

            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var reservation = await _reservationService.GetByReservationIdAsync(id.Value);

            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReservationId,MainGuestName,TotalAmount,Confirmed,FromDate,ToDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                await _reservationService.EditReservationAsync(reservation);

                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var reservation = await _reservationService.GetByReservationIdAsync(id.Value);

            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var reservation = await _reservationService.GetByReservationIdAsync(id);

            await _reservationService.DeleteReservationAsync(reservation);

            return RedirectToAction("Index");
        }
    }
}
