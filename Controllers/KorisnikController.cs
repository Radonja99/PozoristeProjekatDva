﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PozoristeProjekat.DTOs;
using PozoristeProjekat.DTOs.Base;
using PozoristeProjekat.DTOs.Confirmations;
using PozoristeProjekat.DTOs.Creations;
using PozoristeProjekat.DTOs.Updates;
using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using PozoristeProjekat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Controllers
{
    [Route("api/korisnik")]
    public class KorisnikController : ControllerBase
    {
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IKorisnikRepository korisnikRepository;
        private readonly IJWTAuth _jwtAuth;

        public KorisnikController(LinkGenerator linkGenerator, IMapper mapper, IKorisnikRepository korisnikRepository, IJWTAuth jWTAuth)
        {
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.korisnikRepository = korisnikRepository;
            _jwtAuth = jWTAuth;
        }

  //      [Authorize(Roles = "admin")]
        public ActionResult<List<KorisnikDTO>> GetKorisnikSve()
        {
            var korisnik = korisnikRepository.GetKorisnik();
            if (korisnik == null || korisnik.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<KorisnikDTO>>(korisnik));
        }
        [HttpGet("{korisnikID}")]
        public ActionResult<KorisnikDTO> getKorisnik(Guid korisnikID)
        {
            var korisnik = korisnikRepository.GetKorisnikById(korisnikID);
            if (korisnik == null )
            {
                return NotFound();
            }
            return Ok(mapper.Map<KorisnikDTO>(korisnik));
        }

        [HttpPost]
 //        [Authorize(Roles = "admin")]
        public ActionResult<KorisnikConfirmationDTO> CreateKorisnik([FromBody] KorisnikCreationDTO korisnik)
        {
            try
            {
                Korisnik korisnikEntity = mapper.Map<Korisnik>(korisnik);
                KorisnikConfirmation confirmation = korisnikRepository.CreateKorisnik(korisnikEntity);

                korisnikRepository.SaveChanges();

                string location = linkGenerator.GetPathByAction("GetKorisnikSve", "Korisnik", new { KorisnikID = confirmation.KorisnikID });
                return Created(location, mapper.Map<KorisnikConfirmationDTO>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");

            }
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{korisnikID}")]
        public IActionResult DeleteKorisnik(Guid korisnikID)
        {
            try
            { 
            var korisnik = korisnikRepository.GetKorisnikById(korisnikID);
                if (korisnik == null)
                {
                    return NotFound();
                }
                korisnikRepository.DeleteKorisnik(korisnikID);
                korisnikRepository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greska pri brisanju");
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{KorisnikID}")]
        public ActionResult<KorisnikConfirmationDTO> UpdateKorisnik(KorisnikUpdateDTO korisnik)
        {
            try
            {
                if (korisnikRepository.GetKorisnikById(korisnik.KorisnikID) == null)
                {
                    return NotFound();
                }
                Korisnik korisnik2 = mapper.Map<Korisnik>(korisnik);
                KorisnikConfirmation confirmation = korisnikRepository.UpdateKorisnik(korisnik2);
                korisnikRepository.SaveChanges();
                return Ok(mapper.Map<KorisnikConfirmationDTO>(confirmation));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        //[AllowAnonymous]
        // POST api/<MembersController>
        [HttpPost("login")]
        public IActionResult Authentication([FromBody] KorisnikLoginDTO korisnik)
        {
            Korisnik korisnikModel = korisnikRepository.GetByKorisnickoIme(korisnik.KorisnickoIme);
            if (korisnikModel == null || korisnikModel.LozinkaKorisnika != korisnik.LozinkaKorisnika)
            {
                return Unauthorized();
            }
            var token = _jwtAuth.Authentication(korisnik.KorisnickoIme, korisnik.LozinkaKorisnika, korisnikRepository);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }


    }
