using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    internal class Tensor
    {
        private int[] _shape { get; }
        private int[] _data { get; }

        public int this[params int[] indices]
        {
            get
            {
                int index = 0;
                for (int i = 0; i < indices.Length; i++)
                {
                    index += indices[i] * _shape.Skip(i).Aggregate((a, b) => a * b) / _shape[i];
                }
                return _data[index];
            }
            set
            {
                int index = 0;
                for (int i = 0; i < indices.Length; i++)
                {
                    index += indices[i] * _shape.Skip(i).Aggregate((a, b) => a * b) / _shape[i];
                }
                _data[index] = value;
            }
        }
        
        public Tensor(params int[] shape)
        {
            _shape = shape;
            _data = new int[shape.Aggregate((a, b) => a * b)];
        }
        
        public void Fill(int value = 0)
        {
            if (_shape.Length == 1)
            {
                for (int i = 0; i < _data.Length; i++)
                {
                    _data[i] = value;
                }
            }
            else if (_shape.Length == 2)
            {
                for (int i = 0; i < _shape[0]; i++)
                {
                    for (int j = 0; j < _shape[1]; j++)
                    {
                        this[i, j] = j;
                    }
                }
            }
            else if (_shape.Length == 3)
            {
                for (int i = 0; i < _shape[0]; i++)
                {
                    for (int j = 0; j < _shape[1]; j++)
                    {
                        for (int k = 0; k < _shape[2]; k++)
                        {
                            this[i, j, k] = 1;
                        }
                    }
                }
            }
            else if (_shape.Length == 4)
            {
                for (int i = 0; i < _shape[0]; i++)
                {
                    for (int j = 0; j < _shape[1]; j++)
                    {
                        for (int k = 0; k < _shape[2]; k++)
                        {
                            for (int l = 0; l < _shape[3]; l++)
                            {
                                this[i, j, k, l] = 1;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public string StringDimensions()
        {
            return ($"Count of dimensions: {_shape.Length}\nShape: {string.Join(", ", _shape)}");
        }

        public string ToString()
        {
            var sb = new StringBuilder();
            if (_shape.Length == 1)
            {
                sb.Append($"[{string.Join(", ", _data)}]");
            }
            else if (_shape.Length == 2)
            {
                sb.Append("[");
                for (int i = 0; i < _shape[0]; i++)
                {
                    sb.Append("[");
                    for (int j = 0; j < _shape[1]; j++)
                    {
                        sb.Append(this[i, j]);
                        if (j < _shape[1] - 1) sb.Append(", ");
                    }
                    sb.Append("]");
                    if (i < _shape[0] - 1) sb.Append(", ");
                }
                sb.Append("]");
            }
            else if (_shape.Length == 3)
            {
                sb.Append("[");
                for (int i = 0; i < _shape[0]; i++)
                {
                    sb.Append("[");
                    for (int j = 0; j < _shape[1]; j++)
                    {
                        sb.Append("[");
                        for (int k = 0; k < _shape[2]; k++)
                        {
                            sb.Append(this[i, j, k]);
                            if (k < _shape[2] - 1) sb.Append(", ");
                        }
                        sb.Append("]");
                        if (j < _shape[1] - 1) sb.Append(", ");
                    }
                    sb.Append("]");
                    if (i < _shape[0] - 1) sb.Append(", ");
                }
                sb.Append("]");
            }
            else if (_shape.Length == 4)
            {
                sb.Append("[");
                for (int i = 0; i < _shape[0]; i++)
                {
                    sb.Append("[");
                    for (int j = 0; j < _shape[1]; j++)
                    {
                        sb.Append("[");
                        for (int k = 0; k < _shape[2]; k++)
                        {
                            sb.Append("[");
                            for (int l = 0; l < _shape[3]; l++)
                            {
                                sb.Append(this[i, j, k, l]);
                                if (l < _shape[3] - 1) sb.Append(", ");
                            }
                            sb.Append("]");
                            if (k < _shape[2] - 1) sb.Append(", ");
                        }
                        sb.Append("]");
                        if (j < _shape[1] - 1) sb.Append(", ");
                    }
                    sb.Append("]");
                    if (i < _shape[0] - 1) sb.Append(", ");
                }
                sb.Append("]");
            }
            else
            {
                throw new NotImplementedException();
            }
            return sb.ToString();
        }
    }
}
