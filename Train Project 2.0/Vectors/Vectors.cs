﻿using System;
using System.Drawing;
using TrainProject.JunctionEditor;

namespace TrainProject.Vectors
{
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public static PointF Create(float x, float y)
        {
            return new PointF(x,y);
        }

        public static PointF Create(PointF from, PointF to)
        {
            return new PointF(to.X - from.X, to.Y - from.Y);
        }

        public static PointF Create(IPositionable a, IPositionable b)
        {
            return new PointF(b.Position.X - a.Position.X, b.Position.Y - a.Position.Y);
        }

        public static float VectorLength(PointF vector)
        {
            var a = vector.X * vector.X;
            var b = vector.Y * vector.Y;
            return (float)Math.Sqrt(a + b);
        }

        public static PointF Normalize(PointF vector)
        {
            var length = VectorLength(vector);
            return new PointF(vector.X / length, vector.Y / length);
        }

        public static PointF MultiplyByScalar(PointF vector, float k)
        {
            return new PointF(k * vector.X, k * vector.Y);
        }

        public static PointF Addition(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        public static PointF Divide(PointF a, PointF b)
        {
            return new PointF(a.X - b.X, a.Y - b.Y);
        }

        public static float Distance(PointF a, PointF b)
        {
            return VectorLength(Create(a, b));
        }

        public static float Distance(IPositionable a, IPositionable b)
        {
            return VectorLength(Create(a, b));
        }

        public static float Multiply(PointF a, PointF b)
        {
            return a.X*b.X + a.Y*b.Y;
        }

        public static PointF MapPointToVector(PointF a, PointF b, PointF c)
        {
            var main = Create(a, b);
            var e = Normalize(main);

            var vectorToMapping = Create(a, c);
            var scalarMultiplication = Multiply(vectorToMapping, e);
            var mappedVector = MultiplyByScalar(e, scalarMultiplication);
            
            return new PointF(a.X + mappedVector.X, a.Y + mappedVector.Y);            
        }

        public static implicit operator PointF(Vector v)
        {
            return new PointF(v.X, v.Y);
        }

        public static implicit operator Vector(PointF pointF)
        {
            return new Vector
            {
                X = pointF.X,
                Y = pointF.Y
            };
        }
    }
}
