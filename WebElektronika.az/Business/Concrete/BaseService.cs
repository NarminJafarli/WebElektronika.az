using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebElektronika.az.Business.Abstract;
using WebElektronika.az.Models.Context;

namespace WebElektronika.az.Business.Concrete
{
    public class BaseService<RsDTO, T, RqDTO> : IBaseService<RsDTO, T, RqDTO> where T : class
    {
        public readonly IMapper _mapper;
        public readonly AppDbContext _dbContext;
        public readonly DbSet <T> _dbSet;

        public BaseService(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Delete(int id)
        {
           var ent = _dbSet.Find(id);   
            _dbSet.Remove(ent);
            _dbContext.SaveChanges();
        }

        public List<RsDTO> GetAll()
        {
            var ent= _dbSet.ToList();
            var rsdto= _mapper.Map<List<RsDTO>>(ent);
            return rsdto;
            
        }

		public RsDTO GetByID(int id)
		{
			var ent = _dbSet.Find(id);
			var rsdto = _mapper.Map<RsDTO>(ent);
			return rsdto;

		}

		public void Insert(RqDTO dto)
        {
          var ent=_mapper.Map<T>(dto);
          _dbSet.Add(ent);
            _dbContext.SaveChanges();
        }

        public void Update(RqDTO dto)
        {
            var ent = _mapper.Map<T>(dto);
            _dbSet.Update(ent);
            _dbContext.SaveChanges();
        }

		RsDTO IBaseService<RsDTO, T, RqDTO>.Insert(RqDTO dto)
		{
			throw new NotImplementedException();
		}
	}
}
