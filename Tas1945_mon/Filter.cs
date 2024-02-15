using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
	public partial class MainForm : Form
	{
		bool g_bKalman_Init = false;
		double[] g_adbKalMan_PredCov = new double[4860];			//	예측 공분산(Predicted Covariance)
		double[] g_adbKalMan_Value = new double[4860];				//	현 추정값
		double[] g_adbKalMan_PredNoiseCov = new double[4860];		//	예측 노이즈 공분산(Predicted Noise Covariance)
		double[] g_adbKalMan_MeasNoiseCov = new double[4860];		//	측정 노이즈 공분산(Measurement Noise Covariance)
		double[] g_adbKalMan_Gain = new double[4860];               //	칼만게인

		public bool s_bInitKalamn;          // digital filter init
		public double s_dKalmanGain;            // kalman gain 	(kg)
		public double s_dKalmanest;             // kalman est		(ke)

		public double[] s_dKalman_Gain = new double[4860];   // kalman gain 배열형 (kg)
		public float[] s_dKalman_est = new float[4860];        // kalman est 배열형 (ke) 

		/// <summary>
		/// 
		/// </summary>
		public void Kalman_Init ()
		{
			g_bKalman_Init = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sSource"></param>
		/// <returns></returns>
		public float Kalman_Filter (double dbSource, int iIndex)
		{
			try
			{
				if (g_bKalman_Init == false)
				{
					for (int i = 0; i < 4860; i++)
					{
						g_adbKalMan_PredCov[i] = 1.0;						//	예측 공분산(Predicted Covariance)
						g_adbKalMan_Value[i] = 0.99;						//	현 추정값
						g_adbKalMan_PredNoiseCov[i] = Math.Pow (0.5, 1);	//	예측 노이즈 공분산(Predicted Covariance)
						g_adbKalMan_MeasNoiseCov[i] = Math.Pow (0.01, 1);	//	측정 노이즈 공분산(Measurement Covariance)
						g_adbKalMan_Gain[i] = 1.0;							//	칼만게인 (Gain 이 커지면 반응 속도가 빨라진다.)
					}

					g_bKalman_Init = true;
				}

				g_adbKalMan_PredCov[iIndex] = g_adbKalMan_PredCov[iIndex] + g_adbKalMan_PredNoiseCov[iIndex];									//	예측 공분산 = 현 공분산 + 예측 노이즈 공분산
				g_adbKalMan_Gain[iIndex] = g_adbKalMan_PredCov[iIndex] / (g_adbKalMan_PredCov[iIndex] + g_adbKalMan_MeasNoiseCov[iIndex]);		//	칼만 게인 = 예측 공분산 Matrix / (예측 노이즈 공분산 + 측정 노이즈 공분산)
				g_adbKalMan_Value[iIndex] = g_adbKalMan_Gain[iIndex] * dbSource + (1 - g_adbKalMan_Gain[iIndex]) * g_adbKalMan_Value[iIndex];	//	예측 상태값(추정값) = 칼만 게인 * 소스데이터 + (1 - 칼만게인) * 현 추정값
				g_adbKalMan_PredCov[iIndex] = g_adbKalMan_PredCov[iIndex] * (1 - g_adbKalMan_Gain[iIndex]);										//	예측 공분산에 칼만 게인을 곱한다.
			}
			catch (Exception)
			{
				;
			}
	
			return	(float)g_adbKalMan_Value[iIndex];
		}

		bool g_bLpf_Iir_FirstData = false;
		double[] g_adbLpf_Iir_Result = new double[4860];

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbSensitive"></param>
		public void LPF_IIR_Init (double dbSensitive)
		{
			try
			{
				g_bLpf_Iir_FirstData = false;		//	Sensitivie 는 default 0.1
			}
			catch (Exception)
			{
				;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sSource"></param>
		/// <param name="iSourceLength"></param>
		public void LPF_IIR_SetFirstData (float[] sSource, int iSourceLength)
		{
			try
			{
				if (g_bLpf_Iir_FirstData == true)	return;

				Array.Copy (sSource, 0, g_adbLpf_Iir_Result, 0, iSourceLength);

				g_bLpf_Iir_FirstData = true;
			}
			catch (Exception)
			{
				;
			}
		}

		/// <summary>
		/// Infinite impulse response filter
		/// </summary>
		/// <param name="dbSource"></param>
		/// <param name="iIndex"></param>
		/// <returns></returns>
		public float LPF_IIR_Filter (double dbSource, int iIndex, double dbSensitive)
		{
			try
			{
				g_adbLpf_Iir_Result[iIndex] = g_adbLpf_Iir_Result[iIndex] * (1 - dbSensitive) + dbSource * dbSensitive;
			}
			catch (Exception)
			{
				;
			}

			return (float)g_adbLpf_Iir_Result[iIndex];
		}

		/// <summary>
		/// 20231108 박사님 지시로 칼만필터 추가.
		/// 단일 pixel data를 받아서 하는 함수. 일단 원형 보존을 위해 남겨둠
		/// </summary>
		/// <param name="dData"></param>
		/// <param name="dMeasurementError"></param>
		/// <returns></returns>
		/*
		public double DigitalFilter_Kalman_origin(double dData, double dMeasurementError)
		{
			if (s_bInitKalamn == false)                     // init kalman 
			{
				s_dKalmanGain = 1.0;                            // gain default - 1.0
				s_dKalmanest = dData;                       // est	default - start value
				s_bInitKalamn = true;                           // init end
			}
			else //(l_bool_InitKalman != false)
			{
				// kalman est 
				s_dKalmanest = (1.0 - s_dKalmanGain) * s_dKalmanest + s_dKalmanGain * dData;

				// kalman gain
				s_dKalmanGain = Math.Abs(dData - s_dKalmanest) / (dMeasurementError + Math.Abs(dData - s_dKalmanest));
			}
			return s_dKalmanest;
		}
		*/

		/// <summary>
		/// 20231108 박사님 지시로 칼만필터 추가.
		/// 위의 단일 pixel data 처리에서 배열로 처리하는 함수로 변경함 - v2.05
		/// </summary>
		/// <param name="dData"></param>
		/// <param name="dMeasurementError"></param>
		/// <returns></returns>
		public void DigitalFilter_Kalman(ref float[] asPixelData, int iPixelDataSize, double dMeasurementError)
		{
			if (iPixelDataSize > 4860) return;

			// 원본데이터에 칼만 적용하여 est배열에 모음
			if (s_bInitKalamn == false)                     // init kalman 
			{                   
				for (int i = 0; i < iPixelDataSize; i++)
                {
					s_dKalman_Gain[i] = 1.0;                // gain default - 1.0
					s_dKalman_est[i] = asPixelData[i];         // est	default - start value
				}
				s_bInitKalamn = true;                           // init end
			}
			else //(l_bool_InitKalman != false)
			{
				for (int i = 0; i < iPixelDataSize; i++)
				{
					s_dKalman_est[i] = (float)((1.0 - s_dKalman_Gain[i]) * s_dKalman_est[i] + s_dKalman_Gain[i] * asPixelData[i]);

					s_dKalman_Gain[i] = Math.Abs(asPixelData[i] - s_dKalman_est[i])
													/ (dMeasurementError + Math.Abs(asPixelData[i] - s_dKalman_est[i]));
				}
			}

			// est배열의 값을 원본데이터에 투입
			for (int i = 0; i < iPixelDataSize; i++)
            {
				asPixelData[i] = s_dKalman_est[i];
			}

			return ;
		}
		/// <summary>
		/// 20240106 칼만필터 함수 추가로 작성
		/// 각 Pixel의 노이즈 수준을 기반으로 M.E 값이 정해지도록 분리하여 적용
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		/// <param name="dMeasurementError"></param>
		public void DigitalFilter_Kalman_Each(ref float[] asPixelData, int iPixelDataSize, double[,] dMeasurementError)
		{
			if (iPixelDataSize > 4860) return;

			// 원본데이터에 칼만 적용하여 est배열에 모음
			if (s_bInitKalamn == false)                     // init kalman 
			{
				for (int i = 0; i < iPixelDataSize; i++)
				{
					s_dKalman_Gain[i] = 1.0;                // gain default - 1.0
					s_dKalman_est[i] = asPixelData[i];         // est	default - start value
				}
				s_bInitKalamn = true;                           // init end
			}
			else //(l_bool_InitKalman != false)
			{
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					s_dKalman_est[i] = (float)((1.0 - s_dKalman_Gain[i]) * s_dKalman_est[i] + s_dKalman_Gain[i] * asPixelData[i]);

					s_dKalman_Gain[i] = Math.Abs(asPixelData[i] - s_dKalman_est[i])
													/ (dMeasurementError[row,col] + Math.Abs(asPixelData[i] - s_dKalman_est[i]));
				}
			}

			// est배열의 값을 원본데이터에 투입
			for (int i = 0; i < iPixelDataSize; i++)
			{
				asPixelData[i] = s_dKalman_est[i];
			}

			return;
		}
		/// <summary>
		/// 20240207 칼만필터 함수 추가로 작성
		/// 각 Pixel의 노이즈 수준을 기반으로 M.E 값이 정해지도록 분리하여 적용
		/// 박사님께서 보내신 메일의 방법으로, GAIN을 구하는 방식이 약간 달라짐
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		/// <param name="dMeasurementError"></param>
		public void Kalman_20240207(ref float[] asPixelData, int iPixelDataSize, double[,] dMeasurementError)
		{
			if (iPixelDataSize > 4860) return;

			// 원본데이터에 칼만 적용하여 est배열에 모음
			if (s_bInitKalamn == false)                     // init kalman 
			{
				for (int i = 0; i < iPixelDataSize; i++)
				{
					s_dKalman_Gain[i] = 1.0;                // gain default - 1.0
					s_dKalman_est[i] = asPixelData[i];         // est	default - start value
				}
				s_bInitKalamn = true;                           // init end
			}
			else //(l_bool_InitKalman != false)
			{
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					s_dKalman_Gain[i] = (dMeasurementError[row, col]
													/ (Math.Abs(asPixelData[i] - s_dKalman_est[i]) + dMeasurementError[row, col]));

					s_dKalman_est[i] = (float)((1.0f - s_dKalman_Gain[i]) * asPixelData[i] + s_dKalman_Gain[i] * s_dKalman_est[i]);
					
					asPixelData[i] = s_dKalman_est[i];
				}
			}

			return;
		}
	}
}
