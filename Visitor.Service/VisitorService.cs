using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Core.Domain;
using Visitor.Service.DTO;

namespace Visitor.Service
{
    public class VisitorService : BaseEntityService<VisitorRequest>
    {
        //Insert / Add
        public void PrepareAndSave(VisitorRequestDTO visitorRequestDTO)
        {
            var visitorRequest = Mapper.Map<VisitorRequest>(visitorRequestDTO);
            Add(visitorRequest);
        }

        //Update
        public void PrepareAndUpdate(VisitorRequestDTO visitorRequestDTO)
        {
            var visitorRequest = Mapper.Map<VisitorRequest>(visitorRequestDTO);
            visitorRequest.Visitors.Where(x => x.RequestId == 0).ToList().ForEach(item => item.RequestId = visitorRequest.RequestId);
            Update(visitorRequest);
        }

        //Search
        public IEnumerable<VisitorRequestDTO> Search(VisitorSearchFilterDTO filters, out int totalRecords)
        {
            var visitorRequestSearchQuery = All();

            if (!string.IsNullOrWhiteSpace(filters.Company))
            {
                visitorRequestSearchQuery = visitorRequestSearchQuery.Where(x => x.Company.Contains(filters.Company));
            }
            if (!string.IsNullOrWhiteSpace(filters.Visitors))
            {
                visitorRequestSearchQuery = visitorRequestSearchQuery.Where(x => x.Visitors.Any(s => s.FirstName.Contains(filters.Visitors) || s.LastName.Contains(filters.Visitors) || s.MiddleName.Contains(filters.Visitors)));
            }

            //visitorRequestSearchQuery = visitorRequestSearchQuery.OrderBy(x => x.Name).OrderByDescending(x => x.SystemId);
            visitorRequestSearchQuery = visitorRequestSearchQuery.OrderByDescending(x => x.RequestId);

            totalRecords = visitorRequestSearchQuery.Count();
            //Paging
            if (totalRecords > 0 && filters.Offset.HasValue)
            {
                visitorRequestSearchQuery = visitorRequestSearchQuery.Skip(filters.Offset.Value).Take(filters.RowCountPerPage.Value);
            }

            //Add logging here
            List<VisitorRequest> visitorList = visitorRequestSearchQuery.ToList();
            List<VisitorRequestDTO> searchResults = new List<VisitorRequestDTO>();
            searchResults = Mapper.Map<List<VisitorRequestDTO>>(visitorList);
            return searchResults;
        }

        //ViewDetails
        public VisitorRequestDTO ViewDetails(long requestId)
        {
            var visitor = All().Where(x => x.RequestId == requestId).SingleOrDefault();
            return Mapper.Map<VisitorRequestDTO>(visitor);
        }

        public List<VisitorRequestDTO> GetAll()
        {
            return Mapper.Map<List<VisitorRequestDTO>>(All());
        }

        protected override void Update(VisitorRequest entity)
        {
            var existingVisitorRequest = _visitorDbContext.VisitorRequests
                .Where(x => x.RequestId == entity.RequestId)
                .Include(x => x.Requirement)
                .Include(x => x.Visitors)
                .SingleOrDefault();

            if (existingVisitorRequest != null)
            {
                _visitorDbContext.Entry(existingVisitorRequest).CurrentValues.SetValues(entity);
                if (entity.Requirement != null)
                    _visitorDbContext.Entry(existingVisitorRequest.Requirement).CurrentValues.SetValues(entity.Requirement);
                foreach (VisitorIdentity visitor in existingVisitorRequest.Visitors.ToList())
                {
                    if (!entity.Visitors.Any(c => c.VisitorId == visitor.VisitorId))
                    {
                        _visitorDbContext.Visitors.Remove(visitor);
                    }
                }
                foreach (VisitorIdentity visitorToSave in entity.Visitors)
                {
                    var existingVisitor = existingVisitorRequest.Visitors
                         .Where(c => c.VisitorId == visitorToSave.VisitorId && c.VisitorId != 0)
                         .SingleOrDefault();
                    if (existingVisitor != null)
                        _visitorDbContext.Entry(existingVisitor).CurrentValues.SetValues(visitorToSave);
                    else
                    {
                        _visitorDbContext.Entry(visitorToSave).State = EntityState.Added;
                    }
                }
                SaveChanges();
            }
        }
    }
}
