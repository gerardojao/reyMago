﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReyMagoAPI.Entities;
using ReyMagoApi.DataAccess;
using ReyMagoAPI.Core.Interfaces;
using ReyMagoAPI.Core.Models.DTO;
using AutoMapper;
using ReyMagoApi.Core.Helper;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ReyMagoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudIngresoController : ControllerBase
    {

        private readonly ISolicitudIngresoRepository _solicitudRepository;
        private readonly IMapper _mapper;

        public SolicitudIngresoController(ISolicitudIngresoRepository solicitudRepository, IMapper mapper)
        {
            _solicitudRepository = solicitudRepository;
            _mapper = mapper;
        }

        // GET: api/SolicitudIngreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudIngreso>>> GetAllSolicitudes()
        {
            var solicitudes = await _solicitudRepository.GetSolicitudes();
            var solicitudesDto = _mapper.Map<IEnumerable<SolicitudIngresoDTO>>(solicitudes);
            return Ok(solicitudesDto);
        }

       
        [HttpGet("ByGrimorio{name}")]
        public async Task<IActionResult> GetSolicitudIngreso(string name)
        {
            var solicitudIngreso = await _solicitudRepository.GetSolicitudesByGrimorio(name);

            if (solicitudIngreso == null)
            {
                return NotFound();
            }
            else
            {
                var grimDTO = _mapper.Map<IEnumerable<SolicitudIngresoPorGrimorioDTO>>(solicitudIngreso);
                return Ok(grimDTO);
            }           
        }

        // POST: api/SolicitudIngreso
        [HttpPost]
        public async Task<ActionResult> PostSolicitudIngreso(SolicitudIngresoDTO solicitudIngreso)
        {
            var solicitud = _mapper.Map<SolicitudIngreso>(solicitudIngreso);
            await _solicitudRepository.InsertSolicitud(solicitud);
            return Ok(solicitud);
        }

        // PUT: api/SolicitudIngreso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitudIngreso(int id, SolicitudIngresoDTO solicitudIngresoDto)
        {            
            var solicitudIngreso = _mapper.Map<SolicitudIngreso>(solicitudIngresoDto);

            return await _solicitudRepository.UpdateSolicitud(id, solicitudIngreso)
                 ? Ok("Solicitud updated successfully")
                 : NotFound("Solicitud not updated");
           
        }

        [HttpPut("StatusUpdate/{id}")]
        public async Task<IActionResult> PutEstatusSolicitudIngreso(int id, SolicitudIngresoActualizacionEstadoDTO solicitudIngresoDto)
        {
         
            var solicitudIngreso = _mapper.Map<SolicitudIngreso>(solicitudIngresoDto);
            solicitudIngreso.Id = id;

            await _solicitudRepository.UpdateEstatusSolicitud(solicitudIngreso);
            return Ok(solicitudIngreso);
        }      

        // DELETE: api/SolicitudIngreso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitudIngreso(int id)
        {
            return await _solicitudRepository.DeleteSolicitud(id)
                ? Ok("Solicitud deleted successfully")
                : NotFound("Solicitud not found");
        }

        
    }
}
