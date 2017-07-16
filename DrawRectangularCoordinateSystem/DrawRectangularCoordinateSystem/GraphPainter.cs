using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawRectangularCoordinateSystem
{
    public class GraphPainter
    {
        /// <summary>
        /// 本类保存某一类数据的信息
        /// </summary>
        private class SingleTypeData
        {
            public SingleTypeData(string dataType)
            {
                this.Type = dataType;
            }

            /// <summary>
            /// 数据种类
            /// </summary>
            public string Type = string.Empty;

            /// <summary>
            /// 本类数据的最大值，如果最大值和最小值相等，则认为本类数据没有值
            /// </summary>
            public float MaxValue=-99999;
            /// <summary>
            /// 本类数据的最小值
            /// </summary>
            public float MinValue=9999;
            /// <summary>
            /// 向正向5为倍数的值圆整后的值，例如8圆整为10，
            /// </summary>
            public int MaxRoundValue;
            /// <summary>
            /// 向负向5为倍数的值圆整后的值，例如2圆整为0；
            /// </summary>
            public int MinRoundValue;

            /// <summary>
            /// 保存Y坐标轴上长刻度线文本的最宽宽度
            /// </summary>
            public float MaxYAxesTextWidth=0;

            /// <summary>
            /// 本类型数据集合
            /// </summary>
            public List<float> Datas = new List<float>();

            /// <summary>
            /// 处理后的点集
            /// </summary>
            public PointF[] ProcessedPoints = null;

            public void AddData(float data)
            {
                Datas.Add(data);
                if (data > MaxValue)
                {
                    MaxValue = data;
                }
                if (data < MinValue)
                {
                    MinValue = data;
                }
            }

            public void AddData(decimal data)
            {
                AddData(Convert.ToSingle(data));
            }

            public bool IsExistedDatas()
            {
                if (Math.Abs(MaxValue - MinValue) < 0.000001)
                {
                    return false;
                }

                return true;
            }

            /// <summary>
            /// 计算
            /// </summary>
            public void CalculateSizeInfo()
            {
                MaxRoundValue = Convert.ToInt32(Math.Ceiling(MaxValue));
                if (MaxRoundValue % 10 != 0)
                {
                    MaxRoundValue = MaxRoundValue + 10 - MaxRoundValue % 10;
                }
                MinRoundValue = Convert.ToInt32(Math.Floor(MinValue));
                if (MinRoundValue % 10 != 0)
                {
                    MinRoundValue = MinRoundValue - MinRoundValue % 10;
                }

                if (MinRoundValue > 0)
                {
                    MinRoundValue = 0;
                }
            }

            public void ProcessGraphPoints(CoordinateInfo axes, string TestDataInterval)
            {
                List<PointF> ps = new List<PointF>();
                float axesYDecision = 0;
                float secInterval=float.Parse(TestDataInterval);
                axesYDecision = axes.YAxesLength * 1.0f / (this.MaxRoundValue - this.MinRoundValue);
                for (int i = 0; i < Datas.Count; i++)
                {
                    ps.Add(new PointF(secInterval * i * axes.XAxesDecision, axesYDecision * Datas[i]));
                }

                ProcessedPoints = ps.ToArray();
            }
        }

        /// <summary>
        /// 记录坐标系信息
        /// </summary>
        public class CoordinateInfo
        {
            /// <summary>
            /// 坐标轴分为10大段
            /// </summary>
            public const int AXES_BIG_BLOCK_COUNT = 10;

            /// <summary>
            /// 坐标轴每个大段分为10个小段
            /// </summary>
            public const int AXES_SMALL_BLOCK_COUNT = 10;

            /// <summary>
            /// X轴文字高度
            /// </summary>
            public const int AXES_X_TEXT_HEIGHT = 5;

            /// <summary>
            /// X轴长刻度线高度
            /// </summary>
            public const int AXES_X_LONG_GRADUATION_HEIGHT = 5;

            /// <summary>
            /// X轴短刻度线高度
            /// </summary>
            public const int AXES_X_SHORT_GRADUATION_HEIGHT = 2;

            /// <summary>
            /// Y轴长刻度线宽度
            /// </summary>
            public const int AXES_Y_LONG_GRADUATION_WIDTH = 5;

            /// <summary>
            /// Y轴短刻度线宽度
            /// </summary>
            public const int AXES_Y_SHORT_GRADUATION_WIDTH = 2;

            /// <summary>
            /// 图形与边的距离
            /// </summary>
            public const int DISTINCE_FROM_SIDE = 20;

            public Point OriginPoint = new Point();

            public static Font AxesFont = new Font("宋体", 8);

            /// <summary>
            /// X轴长度
            /// </summary>
            public int XAxesLength = 0;

            /// <summary>
            /// 每个坐标轴代表的毫米数
            /// </summary>
            public const int AXES_TOTAL_MILLIMETRE=100;

            /// <summary>
            /// X坐标轴一毫米对应多少像素
            /// </summary>
            public float XAxesDecision = 0;

            /// <summary>
            /// Y坐标轴一毫米对应多少像素
            /// </summary>
            public float YAxesDecision = 0;

            /// <summary>
            /// Y轴长度
            /// </summary>
            public int YAxesLength = 0;
        }        

        public GraphPainter()
        { }

        public void InitGraphPositions(Graphics g, Size clientSize)
        {
            CalculateCoordinateInfo(ref clientSize);
        }       

        private CoordinateInfo m_coordinate = new CoordinateInfo();

        public CoordinateInfo Coordinate
        {
            get
            {
                return m_coordinate;
            }
        }

        private void CalculateCoordinateInfo(ref Size boardSize)
        {
            m_coordinate.OriginPoint.Y = boardSize.Height - CoordinateInfo.AXES_X_LONG_GRADUATION_HEIGHT - CoordinateInfo.AXES_X_TEXT_HEIGHT - CoordinateInfo.DISTINCE_FROM_SIDE;
            m_coordinate.OriginPoint.X = 0;
            m_coordinate.OriginPoint.X += 2*CoordinateInfo.DISTINCE_FROM_SIDE;
            m_coordinate.OriginPoint.X += CoordinateInfo.AXES_Y_LONG_GRADUATION_WIDTH;
            
            m_coordinate.XAxesLength = boardSize.Width - m_coordinate.OriginPoint.X - 2 * CoordinateInfo.DISTINCE_FROM_SIDE;
            m_coordinate.YAxesLength = m_coordinate.OriginPoint.Y - 2 * CoordinateInfo.DISTINCE_FROM_SIDE;
            m_coordinate.XAxesDecision = m_coordinate.XAxesLength * 1.0f / CoordinateInfo.AXES_TOTAL_MILLIMETRE;
            m_coordinate.YAxesDecision = m_coordinate.YAxesLength * 1.0f / CoordinateInfo.AXES_TOTAL_MILLIMETRE;
        }

        private void DrawYAxesLongGraduationText(Graphics g, Brush b, string text, float rightCenterPointX, float rightCenterPointY)
        {
            float textWidth = g.MeasureString(text, CoordinateInfo.AxesFont).Width;
            float fontHeight = CoordinateInfo.AxesFont.Height / 2.0f;
            RectangleF rectf = new RectangleF(rightCenterPointX - textWidth, rightCenterPointY - fontHeight, textWidth, fontHeight * 2);
            g.DrawString(text, CoordinateInfo.AxesFont, b, rectf);
        }

        private void DrawYAxesDataTypeText(Graphics g, Brush b, string text, float rightPointX, float rightPointY, float width)
        {
            float textHeight = g.MeasureString(text, CoordinateInfo.AxesFont,Convert.ToInt32(width)).Height;
            RectangleF rectf = new RectangleF(rightPointX - width, rightPointY - textHeight-CoordinateInfo.AxesFont.Height, width, textHeight);
            g.DrawString(text, CoordinateInfo.AxesFont, b, rectf);
        }

        private void DrawXAxesLongGraduationText(Graphics g, Brush b, string text, float topCenterPointX, float topCenterPointY)
        {
            float textWidth = g.MeasureString(text, CoordinateInfo.AxesFont).Width / 2.0f; ;
            float fontHeight = CoordinateInfo.AxesFont.Height;
            RectangleF rectf = new RectangleF(topCenterPointX - textWidth, topCenterPointY, textWidth * 2, fontHeight);
            g.DrawString(text, CoordinateInfo.AxesFont, b, rectf);
        }

        public void DrawCoordinate(Graphics g, Size boardSize)
        {
            Pen pLine=new Pen(Color.Black,1);
            SolidBrush sb=new SolidBrush(Color.Black);
            StringFormat sf=new StringFormat();
            sf.Alignment= StringAlignment.Center;
            sf.LineAlignment= StringAlignment.Near;

            try
            {
                g.FillRectangle(Brushes.White, 0, 0, boardSize.Width, boardSize.Height);
                RectangleF rectGraphBoard=new RectangleF(m_coordinate.OriginPoint.X, m_coordinate.OriginPoint.Y - m_coordinate.YAxesLength, m_coordinate.XAxesLength, m_coordinate.YAxesLength);
                g.FillRectangle(Brushes.LightGray, rectGraphBoard);
                rectGraphBoard.Y-=CoordinateInfo.AxesFont.Height*1.5f;
                
                float bigStepLen=0;//记录坐标轴两个长刻度线间的距离
                float smallStepLen=0;//记录坐标轴两个短刻度线间的距离
                float baseValue=0;//记录坐标轴原点对应的真实值
                float stepValue=0;//记录坐标轴两个长刻度线间的距离代表的真实值

                #region 画纵坐标
                PointF tmpPoint = new PointF(m_coordinate.OriginPoint.X, m_coordinate.OriginPoint.Y);
                float tmpPointY = 0;

                baseValue = 0;
                stepValue = (CoordinateInfo.AXES_TOTAL_MILLIMETRE - baseValue) * 1.0f / CoordinateInfo.AXES_BIG_BLOCK_COUNT;
                bigStepLen = m_coordinate.YAxesLength * 1.0f / CoordinateInfo.AXES_BIG_BLOCK_COUNT;
                smallStepLen = bigStepLen / CoordinateInfo.AXES_SMALL_BLOCK_COUNT;

                //绘制Y轴                    
                g.DrawLine(pLine, tmpPoint.X, tmpPoint.Y, tmpPoint.X, tmpPoint.Y - m_coordinate.YAxesLength);

                for (int bigStepIndex = 0; bigStepIndex < CoordinateInfo.AXES_BIG_BLOCK_COUNT; bigStepIndex++)
                {
                    tmpPointY = tmpPoint.Y - bigStepLen * bigStepIndex;
                    g.DrawLine(pLine, tmpPoint.X, tmpPointY, tmpPoint.X - CoordinateInfo.AXES_Y_LONG_GRADUATION_WIDTH, tmpPointY);
                    //绘制长刻度线处的文本
                    DrawYAxesLongGraduationText(g, sb, Convert.ToString(baseValue + stepValue * bigStepIndex), tmpPoint.X - CoordinateInfo.AXES_Y_LONG_GRADUATION_WIDTH, tmpPointY);

                    for (int smallStepIndex = 1; smallStepIndex < CoordinateInfo.AXES_SMALL_BLOCK_COUNT; smallStepIndex++)
                    {
                        float tmpHeight = tmpPointY - smallStepIndex * smallStepLen;
                        g.DrawLine(pLine, tmpPoint.X, tmpHeight, tmpPoint.X - CoordinateInfo.AXES_Y_SHORT_GRADUATION_WIDTH, tmpHeight);
                    }
                }

                tmpPointY = tmpPoint.Y - bigStepLen * CoordinateInfo.AXES_BIG_BLOCK_COUNT;
                g.DrawLine(pLine, tmpPoint.X, tmpPointY, tmpPoint.X - CoordinateInfo.AXES_Y_LONG_GRADUATION_WIDTH, tmpPointY);
                //绘制最上面一条长刻度线处的文本
                DrawYAxesLongGraduationText(g, sb, Convert.ToString(baseValue + stepValue * CoordinateInfo.AXES_BIG_BLOCK_COUNT), tmpPoint.X - CoordinateInfo.AXES_Y_LONG_GRADUATION_WIDTH, tmpPointY);
                //绘制最上面一条长刻度线上的数据类型的文本
                DrawYAxesDataTypeText(g, sb, "Y", tmpPoint.X, tmpPointY, CoordinateInfo.AXES_Y_LONG_GRADUATION_WIDTH*2);
#endregion

                g.TranslateTransform(m_coordinate.OriginPoint.X, m_coordinate.OriginPoint.Y);                 

                #region 画横坐标
                g.DrawLine(Pens.Black, 0, 0, m_coordinate.XAxesLength, 0);                
                tmpPoint.Y = 0;
                tmpPoint.X = 0;
                baseValue = 0;
                stepValue=CoordinateInfo.AXES_TOTAL_MILLIMETRE*1.0f / CoordinateInfo.AXES_BIG_BLOCK_COUNT;
                bigStepLen = m_coordinate.XAxesLength * 1.0f / CoordinateInfo.AXES_BIG_BLOCK_COUNT;
                smallStepLen = bigStepLen / CoordinateInfo.AXES_SMALL_BLOCK_COUNT;

                for (int bigStepIndex = 0; bigStepIndex < CoordinateInfo.AXES_BIG_BLOCK_COUNT; bigStepIndex++)
                {
                    tmpPoint.X = bigStepLen * bigStepIndex;
                    g.DrawLine(Pens.Black, tmpPoint.X, tmpPoint.Y, tmpPoint.X, tmpPoint.Y + CoordinateInfo.AXES_X_LONG_GRADUATION_HEIGHT);
                    DrawXAxesLongGraduationText(g, Brushes.Black, Convert.ToString(baseValue + stepValue * bigStepIndex), tmpPoint.X, tmpPoint.Y + CoordinateInfo.AXES_X_LONG_GRADUATION_HEIGHT);
                    for (int smallStepIndex = 1; smallStepIndex < CoordinateInfo.AXES_SMALL_BLOCK_COUNT; smallStepIndex++)
                    {
                        float tmpWidth = tmpPoint.X + smallStepIndex * smallStepLen;
                        g.DrawLine(Pens.Black, tmpWidth, tmpPoint.Y, tmpWidth, tmpPoint.Y + CoordinateInfo.AXES_X_SHORT_GRADUATION_HEIGHT);
                    }

                    
                }

                tmpPoint.X = bigStepLen * CoordinateInfo.AXES_BIG_BLOCK_COUNT;
                g.DrawLine(Pens.Black, tmpPoint.X, tmpPoint.Y, tmpPoint.X, tmpPoint.Y + CoordinateInfo.AXES_X_LONG_GRADUATION_HEIGHT);
                DrawXAxesLongGraduationText(g, Brushes.Black, CoordinateInfo.AXES_TOTAL_MILLIMETRE.ToString(), tmpPoint.X, tmpPoint.Y + CoordinateInfo.AXES_X_LONG_GRADUATION_HEIGHT);
#endregion
            }
            catch (Exception ex)
            {
                throw new Exception("绘制坐标轴失败，错误消息为:" + ex.Message, ex);
            }
            finally
            {
                pLine.Dispose();
                sb.Dispose();
                sf.Dispose();
            }
        }       
    }
}
