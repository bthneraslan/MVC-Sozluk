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
    public class ImageManager :IImageService
    {
        IImageDal _ımageDal;

        public ImageManager(IImageDal ımageDal)
        {
            _ımageDal = ımageDal;
        }

        public void CategoryAdd(ImageFile ımageFile)
        {
            throw new NotImplementedException();
        }

        public ImageFile GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetList()
        {
            return _ımageDal.List();
        }

        public void ImageFileDelete(ImageFile ımageFile)
        {
            throw new NotImplementedException();
        }

        public void ImageFileUpdate(ImageFile ımageFile)
        {
            throw new NotImplementedException();
        }
    }
}
