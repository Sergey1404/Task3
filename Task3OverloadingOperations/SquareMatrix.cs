using System;
namespace Task3OverloadingOperations {
    internal class SquareMatrix : Matrix {
        private static int size { get; set; }
        public static int Size {
            get { return size; }
            set {
                if (value < 1) {
                    size = 1;
                } else {
                    size = value;
                }
            }
        }
        public int[,] MatrixValue;
        public SquareMatrix() {
        }
        public static void FillAuto(SquareMatrix matrix) {
            FillMatrix(ref matrix, Size);
        }
        public void FillAuto() {
            FillMatrix(ref MatrixValue, Size);
        }
        public SquareMatrix DeepCopy() {
            SquareMatrix clone = (SquareMatrix)this.MemberwiseClone();
            return clone;
        }
        public override bool Equals(object obj) {
            return base.Equals(obj);
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        public override string ToString() {
            return base.ToString();
        }
        public static SquareMatrix operator +(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) {
            SquareMatrix TemproraryMatrix = new SquareMatrix();
            TemproraryMatrix.MatrixValue = new int[Size, Size];
            for (int ColIndex = 0; ColIndex < Size; ++ColIndex) {
                for (int RowIndex = 0; RowIndex < Size; ++RowIndex) {
                    TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = FirstMatrix.MatrixValue[ColIndex, RowIndex] + SecondMatrix.MatrixValue[ColIndex, RowIndex];
                }
            }
            PrintOperations(FirstMatrix, SecondMatrix, "+", TemproraryMatrix, Size);
            return TemproraryMatrix;
        }
        public static SquareMatrix operator *(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) {
            SquareMatrix TemproraryMatrix = new SquareMatrix();
            TemproraryMatrix.MatrixValue = new int[Size, Size];
            for (int ColIndex = 0; ColIndex < Size; ++ColIndex) {
                for (int RowIndex = 0; RowIndex < Size; ++RowIndex) {
                    TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = FirstMatrix.MatrixValue[ColIndex, RowIndex] * SecondMatrix.MatrixValue[ColIndex, RowIndex];
                }
            }
            PrintOperations(FirstMatrix, SecondMatrix, "*", TemproraryMatrix, Size);
            return TemproraryMatrix;
        }
        public static SquareMatrix operator -(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) {
            SquareMatrix TemproraryMatrix = new SquareMatrix();
            TemproraryMatrix.MatrixValue = new int[Size, Size];
            for (int ColIndex = 0; ColIndex < Size; ++ColIndex) {
                for (int RowIndex = 0; RowIndex < Size; ++RowIndex) {
                    TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = FirstMatrix.MatrixValue[ColIndex, RowIndex] - SecondMatrix.MatrixValue[ColIndex, RowIndex];
                }
            }
            PrintOperations(FirstMatrix, SecondMatrix, "-", TemproraryMatrix, Size);
            return TemproraryMatrix;
        }
        public static SquareMatrix operator /(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) {
            SquareMatrix TemproraryMatrix = new SquareMatrix();
            TemproraryMatrix.MatrixValue = new int[Size, Size];
            for (int ColIndex = 0; ColIndex < Size; ++ColIndex) {
                for (int RowIndex = 0; RowIndex < Size; ++RowIndex) {
                    try {
                        TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = FirstMatrix.MatrixValue[ColIndex, RowIndex] / SecondMatrix.MatrixValue[ColIndex, RowIndex];
                    } catch {
                        TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = 0;
                    }
                }
            }
            PrintOperations(FirstMatrix, SecondMatrix, "/", TemproraryMatrix, Size);
            return TemproraryMatrix;
        }
        public static bool operator ==(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) {
            int[,] MatrixA = FirstMatrix.MatrixValue;
            int[,] MatrixB = SecondMatrix.MatrixValue;
            if (MatrixA.GetLength(0) != MatrixB.GetLength(0)) {
                PrintOperations(FirstMatrix, SecondMatrix, "==", false, Size);
                return false;
            }
            if (MatrixA.GetLength(1) != MatrixB.GetLength(1)) {
                PrintOperations(FirstMatrix, SecondMatrix, "==", false, Size);
                return false;
            }
            for (int ColIndex = 0; ColIndex < MatrixA.GetLength(0); ColIndex++) {
                for (int RowIndex = 0; RowIndex < MatrixA.GetLength(1); RowIndex++) {
                    if (MatrixA[ColIndex, RowIndex] != MatrixB[ColIndex, RowIndex]) {
                        PrintOperations(FirstMatrix, SecondMatrix, "==", false, Size);
                        return false;
                    }
                }
            }
            PrintOperations(FirstMatrix, SecondMatrix, "==", true, Size);
            return true;
        }
        public static bool operator !=(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) {
            int[,] MatrixA = FirstMatrix.MatrixValue;
            int[,] MatrixB = SecondMatrix.MatrixValue;
            if (MatrixA.GetLength(0) != MatrixB.GetLength(0)) {
                PrintOperations(FirstMatrix, SecondMatrix, "!=", true, Size);
                return true;
            }
            if (MatrixA.GetLength(1) != MatrixB.GetLength(1)) {
                PrintOperations(FirstMatrix, SecondMatrix, "!=", true, Size);
                return true;
            }
            for (int ColIndex = 0; ColIndex < MatrixA.GetLength(0); ColIndex++) {
                for (int RowIndex = 0; RowIndex < MatrixA.GetLength(1); RowIndex++) {
                    if (MatrixA[ColIndex, RowIndex] != MatrixB[ColIndex, RowIndex]) {
                        PrintOperations(FirstMatrix, SecondMatrix, "!=", true, Size);
                        return true;
                    }
                }
            }
            PrintOperations(FirstMatrix, SecondMatrix, "!=", false, Size);
            return false;
        }
        public static SquareMatrix operator >(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) {
            SquareMatrix TemproraryMatrix = new SquareMatrix();
            TemproraryMatrix.MatrixValue = new int[Size, Size];
            for (int ColIndex = 0; ColIndex < Size; ++ColIndex) {
                for (int RowIndex = 0; RowIndex < Size; ++RowIndex) {
                    if (FirstMatrix.MatrixValue[ColIndex, RowIndex] > SecondMatrix.MatrixValue[ColIndex, RowIndex]) {
                        TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = 1;
                    } else {
                        TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = 0;
                    }
                }
            }
            PrintOperations(FirstMatrix, SecondMatrix, ">", TemproraryMatrix, Size);
            return TemproraryMatrix;
        }
        public static SquareMatrix operator <(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) {
            SquareMatrix TemproraryMatrix = new SquareMatrix();
            TemproraryMatrix.MatrixValue = new int[Size, Size];
            for (int ColIndex = 0; ColIndex < Size; ++ColIndex) {
                for (int RowIndex = 0; RowIndex < Size; ++RowIndex) {
                    if (FirstMatrix.MatrixValue[ColIndex, RowIndex] < SecondMatrix.MatrixValue[ColIndex, RowIndex]) {
                        TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = 1;
                    } else {
                        TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = 0;
                    }
                }
            }
            PrintOperations(FirstMatrix, SecondMatrix, "<", TemproraryMatrix, Size);
            return TemproraryMatrix;
        }
        public static SquareMatrix operator >=(SquareMatrix FirstMatrix, SquareMatrix SecondMAtrix) {
            SquareMatrix TemporaryMatrix = new SquareMatrix();
            TemporaryMatrix.MatrixValue = new int[Size, Size];
            for (int ColIndex = 0; ColIndex < Size; ++ColIndex) {
                for (int RowIndex = 0; RowIndex < Size; ++RowIndex) {
                    if (FirstMatrix.MatrixValue[ColIndex, RowIndex] >= SecondMAtrix.MatrixValue[ColIndex, RowIndex]) {
                        TemporaryMatrix.MatrixValue[ColIndex, RowIndex] = 1;
                    } else {
                        TemporaryMatrix.MatrixValue[ColIndex, RowIndex] = 0;
                    }
                }
            }
            PrintOperations(FirstMatrix, SecondMAtrix, ">=", TemporaryMatrix, Size);
            return TemporaryMatrix;
        }
        public static SquareMatrix operator <=(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix) {
            SquareMatrix TemproraryMatrix = new SquareMatrix();
            TemproraryMatrix.MatrixValue = new int[Size, Size];
            for (int ColIndex = 0; ColIndex < Size; ++ColIndex) {
                for (int RowIndex = 0; RowIndex < Size; ++RowIndex) {
                    if (FirstMatrix.MatrixValue[ColIndex, RowIndex] <= SecondMatrix.MatrixValue[ColIndex, RowIndex]) {
                        TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = 1;
                    } else {
                        TemproraryMatrix.MatrixValue[ColIndex, RowIndex] = 0;
                    }
                }
            }
            PrintOperations(FirstMatrix, SecondMatrix, "<=", TemproraryMatrix, Size);
            return TemproraryMatrix;
        }
        private static int Determinant3x3(int[,] MainMatrix) {
            int det = default;
            int a = MainMatrix[0, 0],
                b = MainMatrix[0, 1],
                c = MainMatrix[0, 2],
                d = MainMatrix[1, 0],
                e = MainMatrix[1, 1],
                f = MainMatrix[1, 2],
                g = MainMatrix[2, 0],
                h = MainMatrix[2, 1],
                i = MainMatrix[2, 2];
            det = a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);
            return det;
        }
        private static int DeterminantOver3(int[,] MainMatrix) {
            /*
			a  b  c
			d  e  f
			g  h  i
			|A| = a(ei − fh) − b(di − fg) + c(dh − eg)
			*/
            if (MainMatrix.GetLength(0) == 3) {
                return Determinant3x3(MainMatrix);
            }
            int DetSize = MainMatrix.GetLength(0) - 1,
                det = 0,
                RowIndex = 0,
                ColIndex = 0,
                MatIndex = MainMatrix.GetLength(0);
            int[,] DetMatrix = new int[DetSize, DetSize];
            for (int FirstColInd = 0; FirstColInd < MatIndex; ++FirstColInd) {
                for (int MatrixColumn = 1; MatrixColumn < MatIndex; ++MatrixColumn) {
                    for (int MatrixRow = 0; MatrixRow < MatIndex; ++MatrixRow) {
                        if (MatrixRow == FirstColInd) {
                            continue;
                        } else {
                            DetMatrix[ColIndex, RowIndex++] = MainMatrix[MatrixColumn, MatrixRow];
                        }
                    }
                    RowIndex = 0;
                    ++ColIndex;
                }
                ColIndex = 0;
                RowIndex = 0;
                if (FirstColInd % 2 == 0) {
                    det += MainMatrix[0, FirstColInd] * DeterminantOver3(DetMatrix);
                } else if (FirstColInd % 2 == 1) {
                    det -= MainMatrix[0, FirstColInd] * DeterminantOver3(DetMatrix);
                }
                DetMatrix = new int[DetSize, DetSize];
            }
            return det;
        }
        public static int FindDeterminant(int[,] MainMatrix, bool Print = true) {
            int det = default;
            int MatrixSize = MainMatrix.GetLength(0);
            if (MatrixSize == 2) {
                det = MainMatrix[0, 0] * MainMatrix[1, 1] - MainMatrix[1, 0] * MainMatrix[0, 1];
            } else if (MatrixSize == 3) {
                det = Determinant3x3(MainMatrix);
            } else if (MatrixSize > 3) {
                det = DeterminantOver3(MainMatrix);
            } if (Print) {
                PrintOperations(MainMatrix, det, "FindDeterminant");
            }
            return det;
        }
        public static int[,] FindTranspose(int[,] MainMatrix, bool Print = true {
            int MatrixSize = MainMatrix.GetLength(0);
            int[,] Transpose = new int[MatrixSize, MatrixSize];
            for (int i = 0; i < MatrixSize; ++i) {
                for (int j = 0; j < MatrixSize; ++j) {
                    Transpose[i, j] = MainMatrix[j, i];
                }
            }
            if (Print) {
                PrintOperations(MainMatrix, Transpose, "FindTranspose");
            }
            return Transpose;
        }
        private static int[,] MinorOf3x3(int[,] MainMatrix) {
            /*
				| a11 a12 a13 |
			A =	| a21 a22 a23 |
				| a31 a32 a33 |

						| a22 a23 |
			a11 = M11 =	| a32 a33 | = a22*a33 - a23*a32
			*/
            int MatrixSize = MainMatrix.GetLength(0);
            int a11 = MainMatrix[0, 0],
                a12 = MainMatrix[0, 1],
                a13 = MainMatrix[0, 2],
                a21 = MainMatrix[1, 0],
                a22 = MainMatrix[1, 1],
                a23 = MainMatrix[1, 2],
                a31 = MainMatrix[2, 0],
                a32 = MainMatrix[2, 1],
                a33 = MainMatrix[2, 2];
            int M11 = a22 * a33 - a23 * a32,
                M12 = a21 * a33 - a23 * a31,
                M13 = a21 * a32 - a22 * a31,
                M21 = a12 * a33 - a13 * a32,
                M22 = a11 * a33 - a13 * a31,
                M23 = a11 * a32 - a12 * a31,
                M31 = a12 * a23 - a13 * a22,
                M32 = a11 * a23 - a13 * a21,
                M33 = a11 * a22 - a12 * a21;
            int[,] MinorMatrix = { { M11, M12, M13 }, { M21, M22, M23 }, { M31, M32, M33 } };
            return MinorMatrix;
        }
        private static int[,] MinorOf4x4(int[,] MainMatrix) {
            /*
				| a11 a12 a13 |
			A =	| a21 a22 a23 |
				| a31 a32 a33 |
						| a22 a23 |
			a11 = M11 =	| a32 a33 | = a22*a33 - a23*a32
			*/
            int MatrixSize = MainMatrix.GetLength(0);
            int[,] MinorMatrix = new int[MatrixSize, MatrixSize];
            return MinorMatrix;
        }
        public static int[,] FindMinor(int[,] MainMatrix, bool Print = true) {
            int MatrixSize = MainMatrix.GetLength(0);
            int[,] Minor = new int[MatrixSize, MatrixSize];
            if (MatrixSize == 2) {
                Minor[0, 0] = MainMatrix[1, 1];
                Minor[0, 1] = MainMatrix[1, 0];
                Minor[1, 0] = MainMatrix[0, 1];
                Minor[1, 1] = MainMatrix[0, 0];
            } else if (MatrixSize == 3) {
                Minor = MinorOf3x3(MainMatrix);
            } else if (MatrixSize > 3) {
                throw new IndexOutOfRangeException();
            } if (Print) {
                PrintOperations(MainMatrix, Minor, "FindMinor");
            }
            return Minor;
        }
        public static double[,] FindInverseMatrix(int[,] MainMatrix, bool Print = true) {
            int MatrixSize = MainMatrix.GetLength(0);
            double[,] Inverse = new double[MatrixSize, MatrixSize];
            int[,] Transpose = FindTranspose(MainMatrix, Print: false);
            int Determinant = FindDeterminant(MainMatrix, Print: false);
            double rr = Math.Round(1 / Convert.ToDouble(Determinant), 2);
            for (int ColIndex = 0; ColIndex < MatrixSize; ++ColIndex) {
                for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex) {
                    Inverse[ColIndex, RowIndex] = Math.Round(Convert.ToDouble(Transpose[ColIndex, RowIndex]) * rr, 2);
                }
            } if (Print) {
                PrintOperations(MainMatrix, Inverse, "FindInverseMatrix");
            }
            return Inverse;
        }
    }
}