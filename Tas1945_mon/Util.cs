using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
    public partial class MainForm : Form
    {
        public string ByteArrayToString (byte[] ba)
        {
            try
            {
                StringBuilder hex = new StringBuilder(ba.Length * 2);
                foreach (byte b in ba)
                    hex.AppendFormat ("{0:x2}", b);
                return hex.ToString ();
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
                return null;
            }
        }


        /*
         * C-의 __FUNC__를 구현하기 위한 API
         */
        //public string CallerName ([CallerMemberName] string callerName = "")
        //{
        //   return callerName;
        //}

        /*
         * delay 를 주기 위한 API
         */
        public DateTime Delay (int ms)
        {
            try
            {
                DateTime CurrentTime = DateTime.Now;
                TimeSpan span = new TimeSpan(0, 0, 0, 0, ms);
                DateTime EndTime = CurrentTime.Add(span);
                while (EndTime >= CurrentTime)
                {
                    System.Windows.Forms.Application.DoEvents ();
                    CurrentTime = DateTime.Now;
                }
                return DateTime.Now;
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
                return DateTime.Now;
            }
        }

        /*
         * UInt32 형식의 값을 hex string 값으로 변환한다
         * 변환시 앞에 0x가 붙어서 리턴된다
         */
        public string Uint32ToHexString (UInt32 intVal)
        {
            /*
             * X1 : 한 자리수
             * X2 : 두 자리수
             * X3 : 세 자리수
             */
            try
            {
                return ("0x" + intVal.ToString ("X2"));
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
                return null;
            }
        }

        /*
         * Get 4byte UInt32 from byte array from given index number to index + 3 LSB
         */
        public UInt32 Get4LSB (byte[] data, byte startIdx)
        {
            UInt32 ret = 0;

            try
            {
                ret = (UInt32)(data[startIdx] | data[startIdx + 1] << 8 | data[startIdx + 2] << 16 | data[startIdx + 3] << 24);
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return ret;
        }

        public UInt32 Get4LSB (byte[] data, int startIdx)
        {
            UInt32 ret = 0;

            try
            {
                ret = (UInt32)(data[startIdx] | data[startIdx + 1] << 8 | data[startIdx + 2] << 16 | data[startIdx + 3] << 24);
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return ret;
        }

        public UInt32 Get4LSB (List<byte> data, byte startIdx)
        {
            UInt32 ret = 0;

            try
            {
                ret = (UInt32)(data[startIdx] | data[startIdx + 1] << 8 | data[startIdx + 2] << 16 | data[startIdx + 3] << 24);
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return ret;
        }

        /*
         * Get 4byte UInt32 from byte array from given index number to index + 3 MSB
         */
        public UInt32 Get4MSB (byte[] data, byte startIdx)
        {
            UInt32 ret = 0;

            try
            {
                ret = (UInt32)(data[startIdx] << 24 | data[startIdx + 1] << 16 | data[startIdx + 2] << 8 | data[startIdx + 3]);
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return ret;
        }

        public UInt32 Get4MSB (List<byte> data, byte startIdx)
        {
            UInt32 ret = 0;

            try
            {
                ret = (UInt32)(data[startIdx] << 24 | data[startIdx + 1] << 16 | data[startIdx + 2] << 8 | data[startIdx + 3]);
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return ret;
        }

        /*
         * 하나의 Hex string 을 byte 로 변환.
         * Hex string 을 입력 받아 hex 값으로 처리하고자 할때 사용
         */
        public byte HexStr2Byte (string str)
        {
            byte val = 0;
            try
            {
                val = Convert.ToByte (str, 16);
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return val;
        }

        /*
         * IEEE 754 format 
         */
        public string IEE754_FloatToHexString (float f)
        {
            var bytes = BitConverter.GetBytes(f);
            var i = BitConverter.ToInt32(bytes, 0);
            return "0x" + i.ToString ("X4");
        }

        public float IEE754_HexStringToFloat (string s)
        {
            var i = Convert.ToInt32(s, 16);
            var bytes = BitConverter.GetBytes(i);
            return BitConverter.ToSingle (bytes, 0);
        }

        /*
         * Moving Average
         */
        public double[] Get_MovingAverage (int frameSize, double[] data)
        {
            double[] avgPoints = null;

            try
            {
                double sum = 0;
                avgPoints = new double[data.Length];

                for (int counter = 0; counter <= data.Length - frameSize; counter++)
                {
                    int innerLoopCounter = 0;
                    int index = counter;
                    while (innerLoopCounter < frameSize)
                    {
                        sum = sum + data[index];
                        innerLoopCounter += 1;
                        index += 1;
                    }

                    avgPoints[counter] = sum / frameSize;

                    sum = 0;
                }
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return avgPoints;
        }

        public double[] SMA (double[] samples, int blockSize)
        {
            double[] means = new double[samples.Length];
            int i = 0, j = 0, start = 0;
            try
            {
                for (i = 1; i <= samples.Length; i++)
                {
                    start = (i < blockSize) ? 0 : i - blockSize;
                    double[] m = new double[i - start];
                    for (j = 0; j < m.Length; j++)
                    {
                        m[j] = samples[start + j];
                    }
                    means[i - 1] = m.Average ();
                }
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return means;
        }

        public double[] ExpAvg (double[] samples, double w)
        {
            double[] means = new double[samples.Length];

            try
            {
                means[0] = samples[0];
                for (int i = 1; i < samples.Length; i++)
                {
                    means[i] = w * samples[i] + (1 - w) * means[i - 1];
                }
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }

            return means;
        }

        public UInt16 getU16 (byte[] bBuf, int offset)
        {
            UInt16 ret = 0;
            try
            {
                ret = (UInt16)(bBuf[offset + 1] << 8 | bBuf[offset]);
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return ret;
        }

        public UInt32 getU32 (byte[] bBuf, int offset)
        {
            UInt32 ret = 0;
            try
            {
                ret = (UInt32)(bBuf[offset + 3] << 24 | bBuf[offset + 2] << 16 | bBuf[offset + 1] << 8 | bBuf[offset]);
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return ret;
        }

        public float getFloat (byte[] bBuf, int offset)
        {
            float ret = 0;
            try
            {
                ret = BitConverter.ToSingle (bBuf, offset);
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
            return ret;
        }







        public enum eEndian : byte
        {
            Little,
            Big,
        }

        public enum eDirection : byte
        {
            Right,
            Left,
        }

        public enum eDateType : int
        {
            yyyyMMdd            = 0,
            yyyyMMddHHmmss      = 1,
            HHmmss              = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="abySource"></param>
        /// <param name="abyPattern"></param>
        /// <param name="iStartPos"></param>
        /// <returns></returns>
        public int getIndexOf(byte[] abySource, byte[] abyPattern, int iStartPos = 0)
        {
            int     iSearch_limit = abySource.Length - abyPattern.Length;

			try
			{
				for (int i = iStartPos; i < iSearch_limit; i++)
				{
					if (abySource[i] == abyPattern[0])
					{
						bool bFound = true;

						for (int j = 1; j < abyPattern.Length; j++)
						{
							if (abySource[i + j] != abyPattern[j])
							{
								bFound = false;
								break;
							}
						}

						if (bFound)
						{
							return i;
						}
					}
				}
			}
			catch (Exception)
			{
				return -1;
			}

            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="abyData"></param>
        /// <param name="iStartIdx"></param>
        /// <param name="iDataLen"></param>
        /// <param name="bSpace"></param>
        /// <returns></returns>
        public string HexArrToAscStr (byte[] abyData, int iStartIdx, int iDataLen, bool bSpace)
        {
            int         i;

            StringBuilder sb = new StringBuilder ();

            try
            {
                for (i = 0; i < (iDataLen - 1); i++)
                {
                    if (bSpace == true)
                    {
                        sb.AppendFormat ("{0:X2} ", abyData[iStartIdx + i]);
                    }
                    else
                    {
                        sb.AppendFormat ("{0:X2}", abyData[iStartIdx + i]);
                    }
                }

                sb.AppendFormat ("{0:X2}", abyData[iStartIdx + i]);
            }
            catch (Exception)
            {
                return null;
            }

            return sb.ToString ();
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="byData"></param>
		/// <param name="bSpace"></param>
		/// <returns></returns>
		public string HexToAscStr (byte byData, bool bSpace)
		{
			StringBuilder sb = new StringBuilder ();

			try
			{
				if (bSpace == true)
				{
					sb.AppendFormat ("{0:X2} ", byData);
				}
				else
				{
					sb.AppendFormat ("{0:X2}", byData);
				}
			}
			catch (Exception)
			{
				return null;
			}

			return sb.ToString ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public long GetElapsedTime (DateTime dateTime)
		{
			TimeSpan tsElapsed;

			long    lNowTime = DateTime.Now.Ticks;

			try
			{
				tsElapsed = new TimeSpan (lNowTime - dateTime.Ticks);
			}
			catch (Exception)
			{
				return lNowTime;
			}

			return (long)tsElapsed.TotalMilliseconds;
		}

		/// <summary>
		/// Hex 값을 long 값으로 변환
		/// </summary>
		/// <param name="abyData"></param>
		/// <param name="iStartIdx"></param>
		/// <param name="iDataLen"></param>
		/// <param name="eEn"></param>
		/// <returns></returns>
		public long HexArrToLong (byte[] abyData, int iStartIdx, int iDataLen, eEndian eEn)
		{
			long        lResult, lMul;
			byte        byTemp;

			lResult = 0;
			lMul = 1;

			try
			{
				for (int i = 0; i < iDataLen; i++)
				{
					if (eEn == eEndian.Little)
					{
						byTemp = abyData[i + iStartIdx];
					}
					else
					{
						byTemp = abyData[iStartIdx + iDataLen - 1 - i];
					}

					lResult += byTemp * lMul;
					lMul *= 256;
				}
			}
			catch (Exception)
			{
				return 0;
			}

			return lResult;
		}

		/// <summary>
		/// Hex 값을 ulong 값으로 변환
		/// </summary>
		/// <param name="abyData"></param>
		/// <param name="iStartIdx"></param>
		/// <param name="iDataLen"></param>
		/// <param name="eEn"></param>
		/// <returns></returns>
		public ulong HexArrToUlong (byte[] abyData, int iStartIdx, int iDataLen, eEndian eEn)
		{
			ulong       ulResult, ulMul;
			byte        byTemp;

			ulResult = 0;
			ulMul = 1;

			try
			{
				for (int i = 0; i < iDataLen; i++)
				{
					if (eEn == eEndian.Little)
					{
						byTemp = abyData[i + iStartIdx];
					}
					else
					{
						byTemp = abyData[iStartIdx + iDataLen - 1 - i];
					}

					ulResult += byTemp * ulMul;
					ulMul *= 256;
				}
			}
			catch (Exception)
			{
				return 0;
			}

			return ulResult;
		}

		/// <summary>
		/// Hex array 를 string 으로 변환
		/// </summary>
		/// <param name="abyData"></param>
		/// <param name="iDataLen"></param>
		/// <returns></returns>
		public string HexArrToStr (byte[] abyData, int iStartIdx, int iDataLen)
		{
			StringBuilder sb = new StringBuilder ();

			try
			{
				for (int i = 0; i < iDataLen; i++)
				{
					if (abyData[iStartIdx + i] != 0)
					{
						sb.Append ((char)abyData[iStartIdx + i]);
					}
					else
					{
						break;
					}
				}
			}
			catch (Exception)
			{
				return null;
			}

			return sb.ToString ();
		}

		/// <summary>
		/// Ulong 값을 string 으로 변환
		/// </summary>
		/// <param name="arg"></param>
		/// <param name="bSpeace"></param>
		/// <returns></returns>
		public string UlongToAscStr (ulong ulData, bool bSpeace)
		{
			StringBuilder sb = new StringBuilder ();

			try
			{
				if (bSpeace == true)
				{
					sb.AppendFormat ("{0:X} ", ulData);
				}
				else
				{
					sb.AppendFormat ("{0:X}", ulData);
				}
			}
			catch (Exception)
			{
				return null;
			}

			return sb.ToString ();
		}

		/// <summary>
		/// String 값을 hex array 로 변환한다.
		/// </summary>
		/// <param name="strData"></param>
		/// <returns></returns>
		public int AscStrToHexArr (string strData, ref byte[] abyData)
		{
			int         i;

			if (strData == null)
			{
				return 0;
			}

			if (strData.Length > 2048)
			{
				return 0;
			}

			try
			{
				for (i = 0; i < strData.Length; i += 2)
				{
					abyData[i / 2] = Convert.ToByte (strData.Substring (i, 2), 16);
				}
			}
			catch (Exception)
			{
				return 0;
			}

			return (i / 2);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strData"></param>
		/// <param name="byData"></param>
		/// <returns></returns>
		public int AscStrToHex (string strData, ref byte byData)
		{
			if (strData == null)
			{
				return 0;
			}

			if (strData.Length > 2)
			{
				return 0;
			}

			try
			{
				byData = Convert.ToByte (strData.Substring (0, 2), 16);
			}
			catch (Exception)
			{
				return 0;
			}

			return 1;
		}

		/// <summary>
		/// String 값중 speace 값을 제거 한다.
		/// </summary>
		/// <param name="strData"></param>
		/// <returns></returns>
		public string RemoveSpeace (string strData)
		{
			string          strReData;

			strReData = string.Empty;

			try
			{
				for (int i = 0; i < strData.Length; i++)
				{
					if (strData.Substring (i, 1) == " ") continue;
					strReData += strData.Substring (i, 1);
				}
			}
			catch (Exception)
			{
				return null;
			}

			return strReData;
		}

		/// <summary>
		/// 현재 시간을 지정된 형태로 가져 온다
		/// </summary>
		/// <returns></returns>
		public string GetNowTime (string strFormat)
		{
			string      strResult;

			strResult = string.Empty;

			try
			{
				if (string.Compare (strFormat, "HHmmss") == 0)
				{
					strResult = string.Format ("{0:HHmmss}", DateTime.Now);
				}
			}
			catch (Exception)
			{
				return null;
			}

			return strResult;
		}

		/// <summary>
		/// Source string 을 지정된 형태로 변환해 준다.
		/// </summary>
		/// <param name="strSource"></param>
		/// <param name="strFormat"></param>
		/// <returns></returns>
		public string ConvertTimeFormat (string strSource, string strFormat)
		{
			string      strResult;

			strResult = string.Empty;

			try
			{
				if (string.Compare (strFormat, "yyyy-MM-dd HH:mm:ss") == 0)
				{
					strResult   = strSource.Substring (0, 4) + "-"          //	yyyy
								+ strSource.Substring (4, 2) + "-"          //	MM
								+ strSource.Substring (6, 2) + " "          //	dd
								+ strSource.Substring (8, 2) + ":"          //	HH
								+ strSource.Substring (10, 2) + ":"         //	mm
								+ strSource.Substring (12, 2);              //	ss
				}
			}
			catch (Exception)
			{
				return null;
			}

			return strResult;
		}

		/// <summary>
		///	설정된 tick 과 현재 tick 을 비교 검사해 준다.
		/// </summary>
		/// <param name="iSetWaitTime"></param>
		/// <returns></returns>
		public bool CheckWait (int iSetWaitTime, DateTime dtStatTime)
		{
			bool        bRet;

			bRet = false;

			try
			{
				if (GetElapsedTime (dtStatTime) >= iSetWaitTime)
				{
					bRet = true;
				}
			}
			catch (Exception)
			{
				return false;
			}

			return bRet;
		}

		/// <summary>
		/// string 을 검사하여 check length 보다 크면 check length 만큼만 잘라낸다
		/// string 을 검사하여 check length 보다 작으면 모자라는 부분을 pad 값으로 채운다.
		/// </summary>
		/// <param name="strSource"></param>
		/// <param name="iCheckLen"></param>
		/// <param name="cPad"></param>
		/// <param name="ePadDir"></param>
		/// <returns></returns>
		public string CheckString (string strSource, int iCheckLen, char cPad, eDirection ePadDir)
		{
			string      strResult, strTemp;

			strResult   = string.Empty;
			strTemp     = string.Empty;

			try
			{
				if (strSource == null)
				{
					strResult = strResult.PadRight (iCheckLen, cPad);
				}
				else
				{
					if (strSource.Length > iCheckLen)
					{
						strResult = strSource.Substring (0, iCheckLen);
					}
					else if (strSource.Length == iCheckLen)
					{
						strResult = strSource;
					}
					else
					{
						if (ePadDir == eDirection.Right)
						{
							strResult = strSource.PadRight (iCheckLen, cPad);
						}
						else
						{
							strResult = strSource.PadLeft (iCheckLen, cPad);
						}
					}
				}
			}
			catch (Exception)
			{
				return strResult;
			}

			return strResult;
		}

		/// <summary>
		/// string 을 검사하여 check length 보다 크면 check length 만큼만 모두 fill 값으로 채운다.
		/// string 을 검사하여 check length 보다 작으면 모자라는 부분을 pad 값으로 채운다.
		/// </summary>
		/// <param name="strSource"></param>
		/// <param name="iCheckLen"></param>
		/// <param name="cFill"></param>
		/// <param name="cPad"></param>
		/// <param name="ePadDir"></param>
		/// <returns></returns>
		public string CheckString (string strSource, int iCheckLen, char cFill, char cPad, eDirection ePadDir)
		{
			string      strResult, strTemp;

			strResult   = string.Empty;
			strTemp     = string.Empty;

			try
			{
				if (strSource == null)
				{
					strResult = strResult.PadRight (iCheckLen, cPad);
				}
				else
				{
					if (strSource.Length > iCheckLen)
					{
						strResult = strResult.PadRight (iCheckLen, cFill);
					}
					else if (strSource.Length == iCheckLen)
					{
						strResult = strSource;
					}
					else
					{
						if (ePadDir == eDirection.Right)
						{
							strResult = strSource.PadRight (iCheckLen, cPad);
						}
						else
						{
							strResult = strSource.PadLeft (iCheckLen, cPad);
						}
					}
				}			
			}
			catch (Exception)
			{
				return strResult;
			}

			return strResult;
		}

		/// <summary>
		/// string 이 null 인지 검사해서 null 이면 string.Empty 를 넣어준다.
		/// </summary>
		/// <param name="strSource"></param>
		/// <returns></returns>
		public string CheckString (string strSource)
		{
			if (strSource == null)
			{
				return string.Empty;
			}

			return strSource;
		}

		/// <summary>
		/// string type 의 datetime 을 검사한다.
		/// </summary>
		/// <param name="strDate"></param>
		/// <returns></returns>
		public bool CheckStringDate (string strDate, eDateType eType)
		{
			bool        bRet;
			int         iIndex;
			long        lConvValue;

			bRet        = false;
			iIndex      = 0;
			lConvValue  = 0;

			if ((eType == eDateType.yyyyMMdd) || (eType == eDateType.yyyyMMddHHmmss))
			{
				if (strDate.Length < 8)
				{
					return false;
				}

				iIndex      = 0;
				lConvValue  = 0;

				if (Int64.TryParse (strDate.Substring (iIndex, 4), out lConvValue) == false)
				{
					return false;
				}

				iIndex += 4;

				if ((lConvValue < 1900) || (lConvValue > 2100))                                 //	yyyy : 1900 ~ 2100 사이
				{
					return false;
				}

				lConvValue  = 0;

				if (Int64.TryParse (strDate.Substring (iIndex, 2), out lConvValue) == false)
				{
					return false;
				}

				iIndex += 2;

				if ((lConvValue < 1) || (lConvValue > 12))                                      //	MM : 1 ~ 12 사이
				{
					return false;
				}

				lConvValue  = 0;

				if (Int64.TryParse (strDate.Substring (iIndex, 2), out lConvValue) == false)
				{
					return false;
				}

				iIndex += 2;

				if ((lConvValue < 1) || (lConvValue > 31))                                      //	dd : 1 ~ 31 사이
				{
					return false;
				}

				bRet = true;
			}

			if ((eType == eDateType.yyyyMMddHHmmss) || (eType == eDateType.HHmmss))
			{
				iIndex = 0;

				if (eType == eDateType.yyyyMMddHHmmss)
				{
					if (strDate.Length < 14)
					{
						return false;
					}

					iIndex += 8;
				}
				else
				{
					if (strDate.Length < 6)
					{
						return false;
					}

					iIndex = 0;
				}

				lConvValue  = 0;

				if (Int64.TryParse (strDate.Substring (iIndex, 2), out lConvValue) == false)
				{
					return false;
				}

				iIndex += 2;

				if ((lConvValue < 0) || (lConvValue > 23))                                      //	HH : 0 ~ 23 사이
				{
					return false;
				}

				lConvValue  = 0;

				if (Int64.TryParse (strDate.Substring (iIndex, 2), out lConvValue) == false)
				{
					return false;
				}

				iIndex += 2;

				if ((lConvValue < 0) || (lConvValue > 59))                                      //	mm : 0 ~ 59 사이
				{
					return false;
				}

				lConvValue  = 0;

				if (Int64.TryParse (strDate.Substring (iIndex, 2), out lConvValue) == false)
				{
					return false;
				}

				iIndex += 2;

				if ((lConvValue < 0) || (lConvValue > 59))                                      //	ss : 0 ~ 59 사이
				{
					return false;
				}

				bRet = true;
			}

			return bRet;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strSource"></param>
		/// <returns></returns>
		public long StringToLong (string strSource)
		{
			long        lTemp;

			try
			{
				lTemp = 0;
				lTemp = long.Parse (strSource);
			}
			catch (Exception)
			{
				lTemp = 0;
			}

			return lTemp;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strSource"></param>
		/// <returns></returns>
		public ulong StringToUlong (string strSource)
		{
			ulong       ulTemp;

			try
			{
				ulTemp = 0;
				ulTemp = ulong.Parse (strSource);
			}
			catch (Exception)
			{
				ulTemp = 0;
			}

			return ulTemp;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strSource"></param>
		/// <returns></returns>
		public int StringToInt (string strSource)
		{
			int     iTemp;

			try
			{
				iTemp = 0;
				iTemp = int.Parse (strSource);
			}
			catch (Exception)
			{
				iTemp = 0;
			}

			return iTemp;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strSource"></param>
		/// <returns></returns>
		public uint StringToUint (string strSource)
		{
			uint    uiTmep;

			try
			{
				uiTmep = 0;
				uiTmep = uint.Parse (strSource);
			}
			catch (Exception)
			{
				uiTmep = 0;
			}

			return uiTmep;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pbyData"></param>
		/// <param name="iSize"></param>
		/// <returns></returns>
		public UInt16 CalCrc16 (byte[] pbyData, int iSize)
		{
			UInt16	u16POLY, u16Crc16, u16CrcTemp, u16Code;
			UInt32  u32Shift;

			u16POLY		= 0xA001;
			u16Crc16	= 0xFFFF;

			for (int i = 0; i < iSize; i++)
			{
				u16Code     = (UInt16)pbyData[i];
				u16Crc16    = (UInt16)(u16Crc16 ^ u16Code);
				u32Shift    = 0;

				while (u32Shift <= 7)
				{
					u16CrcTemp = (UInt16)(u16Crc16 & 0x01);
					if (u16CrcTemp != 0)
					{
						u16Crc16 = (UInt16)(u16Crc16 >> 1);
						u16Crc16 = (UInt16)(u16Crc16 ^ u16POLY);
					}
					else
					{
						u16Crc16 = (UInt16)(u16Crc16 >> 1);
					}

					u32Shift++;
				}
			}

			return u16Crc16;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		public bool HexCheckForInputChar (object sender, KeyPressEventArgs e)
		{
			try
			{
				if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || "ABCDEF0123456789abcdef".IndexOf(e.KeyChar) != -1))		//	숫자와 백스페이스를 제외한 나머지를 바로 처리
				{
					e.Handled = true;

					return	false;
				}
			}
			catch (Exception)
			{
				return	false;
			}

			return	true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ch"></param>
		/// <returns></returns>
		public bool HexCheckForChar (char ch)
		{
			try
			{
				if ("ABCDEF0123456789abcdef".IndexOf(ch) != -1)
				{
					return	false;
				}
			}
			catch (Exception)
			{
				return	false;
			}

			return	true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		public bool DigitCheckForInputChar (object sender, KeyPressEventArgs e)
		{
			try
			{
				if (!char.IsDigit (e.KeyChar) && e.KeyChar != Convert.ToChar (Keys.Back))
				{
					e.Handled = true;

					return	false;
				}
			}
			catch (Exception)
			{
				return false;
			}

			return	true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ch"></param>
		/// <returns></returns>
		public bool DigitCheckForChar (char ch)
		{
			try
			{
				if (!char.IsDigit (ch))
				{
					return	false;
				}
			}
			catch (Exception)
			{
				return false;
			}
		
			return	true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public string GetLocalIP ()
        {
			string localIP = null;

			try
			{
				IPHostEntry		host = Dns.GetHostEntry(Dns.GetHostName());

				foreach (IPAddress ip in host.AddressList)
				{
					if (ip.AddressFamily == AddressFamily.InterNetwork)
					{
						localIP = ip.ToString();
						break;
					}
				}
			}
			catch (Exception)
			{
				return null;
			}

			return	localIP;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="abySrcData"></param>
		/// <param name="iSrcLen"></param>
		/// <param name="iStartIdx"></param>
		/// <param name="iCalCnt"></param>
		/// <param name="iAvrCnt"></param>
		/// <param name="bLittle"></param>
		/// <param name="abyDscData"></param>
		/// <param name="iDscLen"></param>
		/// <returns></returns>
		public bool AverageConvertToUshort (byte[] abySrcData, int iSrcLen, int iStartIdx, int iCalCnt, int iAvrCnt, bool bLittle, ref byte[] abyDscData, ref int iDscLen)
		{
			try
			{
				int			iAvrData;
				int[]		aiAvrData = new int[iCalCnt / 2];

				if (iStartIdx + iCalCnt > iSrcLen)		return	false;

				Array.Clear (aiAvrData, 0, aiAvrData.Length);

				for (int j = 0; j < iAvrCnt; j++)
				{
					for (int i = 0; i < iCalCnt / 2; i++)
					{
						if (bLittle == true)
						{
							iAvrData  = (ushort)(abySrcData[iStartIdx + i * 2 + 0] << 0);
							iAvrData |= (ushort)(abySrcData[iStartIdx + i * 2 + 1] << 8);
						}
						else
						{
							iAvrData  = (ushort)(abySrcData[iStartIdx + i * 2 + 0] << 8);
							iAvrData |= (ushort)(abySrcData[iStartIdx + i * 2 + 1] << 0);
						}

						aiAvrData[i] += iAvrData;
					}
				}

				for (int i = 0; i < iCalCnt / 2; i++)
				{
					aiAvrData[i] /= iAvrCnt;

					abyDscData[iDscLen++] = (byte)(aiAvrData[i] >> 0 & 0x000000FF);
					abyDscData[iDscLen++] = (byte)(aiAvrData[i] >> 8 & 0x000000FF);
				}
			}
			catch (Exception)
			{
				return false;
			}

			return	true;			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		public bool CheckDigit (object sender, KeyPressEventArgs e)
		{
			try
			{
				if (!char.IsDigit (e.KeyChar) && e.KeyChar != Convert.ToChar (Keys.Back))
				{
					e.Handled = true;

					return	false;
				}
			}
			catch (Exception)
			{
				return false;
			}

			return	true;
		}
	}
}
