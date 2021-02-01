using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{ColorId=1, ColorName="Kırmızı"},
                new Color{ColorId=2, ColorName="Beyaz"},
                new Color{ColorId=3, ColorName="Turuncu"},
                new Color{ColorId=4, ColorName="Mavi"}
            };
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Color deleteToColor = _colors.FirstOrDefault(c => c.ColorId == color.ColorId);
            _colors.Remove(deleteToColor);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetById(int colorId)
        {
            return _colors.Where(c => c.ColorId == colorId).ToList();
        }

        public void Update(Color color)
        {
            Color updateToColor = _colors.FirstOrDefault(c => c.ColorId == color.ColorId);
            updateToColor.ColorName = color.ColorName;
        }
    }
}
