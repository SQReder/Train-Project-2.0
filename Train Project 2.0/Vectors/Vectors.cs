using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using TrainProject.JunctionEditor;

namespace TrainProject.Vectors
{
    public class Vector: IEquatable<Vector>
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        #region ctors

        private Vector()
        {
            X = 0;
            Y = 0;
        }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector(PointF from, PointF to)
        {
            X = to.X - from.X;
            Y = to.Y - from.Y;
        }

        public Vector(IPositionable a, IPositionable b)
        {
            X = b.Position.X - a.Position.X;
            Y = b.Position.Y - a.Position.Y;
        }

        #endregion


        public float Length
        {
            get
            {
                var a = X * X;
                var b = Y * Y;
                return (float)Math.Sqrt(a + b);
            }
        }

        public Vector Normalized
        {
            get
            {
                var length = Length;
                return new Vector(X / length, Y / length);
            }
        }

        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y);
        }

        public Vector Substract(Vector v)
        {
            return new Vector(X - v.X, Y - v.Y);
        }

        public float Multiplied(Vector v)
        {
            return X * v.X + Y * v.Y;
        }

        public Vector Multiplied(float k)
        {
            return new Vector(k * X, k * Y);           
        }

        public static PointF MapPointToVector(PointF a, PointF b, PointF c)
        {
            var main = new Vector(a, b);
            var e = main.Normalized;

            var vectorToMapping = new Vector(a, c);
            var scalarMultiplication = vectorToMapping.Multiplied(e);
            var mappedVector = e.Multiplied(scalarMultiplication);
            
            return new PointF(a.X + mappedVector.X, a.Y + mappedVector.Y);            
        }

        #region Casts

        public static explicit operator PointF(Vector v)
        {
            return new PointF(v.X, v.Y);
        }

        public static explicit operator Vector(PointF pointF)
        {
            return new Vector
            {
                X = pointF.X,
                Y = pointF.Y
            };
        }

        public static explicit operator SizeF(Vector v)
        {
            return new SizeF(v.X, v.Y);
        }

        #endregion


        #region IEquatable impelementation

        public bool Equals(Vector other)
        {
            const double tolerance = 0.000000001;
            return Math.Abs(X - other.X) < tolerance && Math.Abs(Y - other.Y) < tolerance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Vector)) return false;
            return Equals((Vector) obj);
        }

        public override int GetHashCode()
        {
            var pointF = (PointF) this;
            return pointF.GetHashCode();
        }

        #endregion

        #region Distance between points

        public static float Distance(PointF a, PointF b)
        {
            return new Vector(a, b).Length;
        }

        public static float Distance(IPositionable a, IPositionable b)
        {
            return new Vector(a, b).Length;
        }

        #endregion

    }
}
