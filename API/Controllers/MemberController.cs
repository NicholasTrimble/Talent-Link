using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class MembersController (AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();
            return members;
        }

        [HttpGet("{id}")] // localhost:5001/api/members/bob-id
        public async Task<ActionResult<AppUser>> GetMember(String Id)
        {
            var member = await context.Users.FindAsync(Id);
            if (member == null) return NotFound();
            return member;
        }
    }
}
