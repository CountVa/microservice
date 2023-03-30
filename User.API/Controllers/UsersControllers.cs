using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using User.API.Models;
using User.DB;
using User.DB.Entitites;

namespace User.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersControllers : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        public UsersControllers(
            MainContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoUser>>> GetUsersAsync()
        {
            var dbUsers = await _context.Users.ToListAsync();
            return _mapper.Map<List<DtoUser>>(dbUsers);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<DtoUser>> GetUsersByIdAsync (int id)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (dbUser == null)
            {
                return NotFound();
            }

            return _mapper.Map<DtoUser>(dbUser);


        }
        [HttpPost]

        public async Task<ActionResult<DtoUser>> PostUserAsync(
            [FromBody] DtoUser dtoUser

        )
        {
            var dbUser = _mapper.Map<DbUser>(dtoUser);

            _context.Users.Add(dbUser);
            await _context.SaveChangesAsync();

            dtoUser = _mapper.Map<DtoUser>(dbUser);

            return dtoUser;
        }
        



        

    }


}
