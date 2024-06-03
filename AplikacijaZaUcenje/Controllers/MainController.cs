using AplikacijaZaUcenje.DATA;
using AplikacijaZaUcenje.Mappers;
using AplikacijaZaUcenje.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace AplikacijaZaUcenje.Controllers
{
    public abstract class MainController<T, TDR, TDI> : ControllerBase where T : Entitet
    {
        protected DbSet<T> DbSet;

        protected Mapping<T, TDR, TDI> _mapper;

        protected abstract void ControlDelete(T entity);

        protected readonly AplikacijaContext _context;

        public MainController(AplikacijaContext context) {

            _context = context;
            _mapper = new Mapping<T, TDR, TDI>();

        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return new JsonResult(ReadAll());
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid || id <= 0) { return BadRequest(ModelState); }

            try
            {
                var entity =  await FindEntity(id);
                return new JsonResult(_mapper.MapInsertUpdateToDTO(entity));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]

        public async Task<IActionResult> Post(TDI entityDTO)
        {
            if (!ModelState.IsValid || entityDTO == null) { return BadRequest(ModelState); }

            try
            {
                var entity = CreateEntity(entityDTO);
                _context.Add(entity);
               await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, _mapper.MapReadToDTO(entity));

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Put(int id, TDI entityTDI)
        {
            if (id <= 0 || !ModelState.IsValid || entityTDI == null) { return BadRequest(ModelState); }

            try
            {
                var entityFromDB = await FindEntity(id);
                _context.Entry(entityFromDB).State = EntityState.Detached;
                var entity = UpdateEntity(entityTDI, entityFromDB);
                entity.ID = id;
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, _mapper.MapReadToDTO(entity));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid || id<=0) { return BadRequest(); }

            try
            {
                var entityFromDB = await FindEntity(id);

                ControlDelete(entityFromDB);
                _context.Remove(entityFromDB);
                await _context.SaveChangesAsync();
                return Ok("Entity deleted!");

            } catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }

        }

        

        protected virtual T UpdateEntity(TDI entityTDI, T entityFromDB)
        {
            return _mapper.MapInsertUpdatedFromDTO(entityTDI);
        } 


        protected virtual T CreateEntity(TDI entityDTO)
        {
            return  _mapper.MapInsertUpdatedFromDTO(entityDTO);
        }

        protected virtual async Task<T> FindEntity(int id)
        {
            var entityFromDB = DbSet.FindAsync(id);
            if(entityFromDB == null)
            {
                throw new Exception("No entity with id " + id + " found in database!!!"); 
            }
            return await entityFromDB;
        }

        protected virtual async Task<List<TDR>> ReadAll()
        {
            var list = await DbSet.ToListAsync();

            if (list == null || list.Count == 0)
            {
                throw new Exception("Database empty");
            }
            return _mapper.MapReadList(list);
        }
    }
}
