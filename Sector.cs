using System;

namespace SectorApp
{
    /// <summary>
    /// Клас, що представляє сектор кола.
    /// </summary>
    public class Sector : IEquatable<Sector>, IComparable<Sector>
    {
        // ---------------- Властивості ----------------
        private double _radius;
        private double _angleDegrees;

        /// <summary>
        /// Радіус сектора (повинен бути > 0)
        /// </summary>
        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Radius), "Radius must be > 0.");
                _radius = value;
            }
        }

        /// <summary>
        /// Кут сектора в градусах (0 < angle ≤ 360)
        /// </summary>
        public double AngleDegrees
        {
            get => _angleDegrees;
            set
            {
                if (value <= 0 || value > 360)
                    throw new ArgumentOutOfRangeException(nameof(AngleDegrees), "Angle must be > 0 and ≤ 360 degrees.");
                _angleDegrees = value;
            }
        }

        // ---------------- Конструктори ----------------
        public Sector(double radius, double angleDegrees)
        {
            Radius = radius;
            AngleDegrees = angleDegrees;
        }

        public Sector()
        {
            _radius = 1.0;
            _angleDegrees = 90.0;
        }

        // ---------------- Методи ----------------

        /// <summary>
        /// Обчислення площі сектора
        /// </summary>
        public double Area()
        {
            return Math.PI * _radius * _radius * _angleDegrees / 360.0;
        }

        /// <summary>
        /// Обчислення довжини дуги сектора
        /// </summary>
        public double ArcLength()
        {
            return 2 * Math.PI * _radius * _angleDegrees / 360.0;
        }

        /// <summary>
        /// Порівняння секторів за площею
        /// </summary>
        public int CompareByArea(Sector other, double tolerance = 1e-9)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            double diff = this.Area() - other.Area();
            if (Math.Abs(diff) < tolerance) return 0;
            return diff > 0 ? 1 : -1;
        }

        /// <summary>
        /// Порівняння секторів (реалізація IComparable)
        /// </summary>
        public int CompareTo(Sector other)
        {
            return CompareByArea(other);
        }

        public bool Equals(Sector other)
        {
            if (other == null) return false;
            return Math.Abs(Radius - other.Radius) < 1e-9 &&
                   Math.Abs(AngleDegrees - other.AngleDegrees) < 1e-9;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Sector);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_radius, _angleDegrees);
        }

        public override string ToString()
        {
            return $"Sector(Radius = {_radius}, Angle = {_angleDegrees}°)";
        }
    }
}
