using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContent _content;

        public ContentManager(IContent content)
        {
            _content = content;
        }

        public void ContentAdd(Content content)
        {
            _content.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _content.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _content.Update(content);
        }

        public Content GetByID(int id)
        {
            return _content.Get(x => x.ContentID == id);
        }

        public List<Content> GetList()
        {
            return _content.List();
        }

        public List<Content> GetListByID(int id)
        {
            return _content.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _content.List(x => x.WriterID == id);
        }
    }
}
