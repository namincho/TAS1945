using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
	partial class MainForm : Form
	{
		/// <summary>
		/// 
		/// </summary>
		private void ToolHint ()
		{
			ttHint.SetToolTip (rbSetIpServer, "Device 를 Server 로 설정 한다.");
			ttHint.SetToolTip (rbSetIpClient, "Device 를 Client 로 설정 한다.");
			ttHint.SetToolTip (ipSetAddress, "Device 의 IP 를 설정 한다.");
			ttHint.SetToolTip (nupSetPort, "Device 의 Port 를 설정 한다. (10000 번 이상의 Port 를 설정)");
			ttHint.SetToolTip (btnIpSetup, "Set IP 명령을 전송 한다.");

			ttHint.SetToolTip (btnSetClock, "Set SPI Clock 명령을 전송 한다.");
			ttHint.SetToolTip (nudSetClock, "SPI Clock 의 정보를 입력 한다. (100, 50, 10 Mhz)");
			ttHint.SetToolTip (btnSetRead, "Set SPI Read 명령을 전송 한다.");
			ttHint.SetToolTip (nudClockDelay, "Read Clock 지연 정보를 입력 한다. (1클럭 단위로  최대 3클럭)");
			ttHint.SetToolTip (tgsReadEdge, "Read Capture Edge 의 정보를 선택 한다. (R-Edge : Rising or F-Edge : Falling)");
			ttHint.SetToolTip (btnSetAverage, "Set Average Count 명령을 전송 한다.");
			ttHint.SetToolTip (nudSetAvrCnt, "Average Count 정보를 입력 한다. (FPAG 의 Average 횟수)");
			ttHint.SetToolTip (btnGetSetupInfo, "Get Setup Info 명령을 전송 한다.");
			ttHint.SetToolTip (btnReset, "Device Reset 명령을 전송한다. UART Consol 로 Version 정보를 전송한다.");
			ttHint.SetToolTip (btnResend, "수신된 명령이 잘 못 되었을 경우 재전송을 요청한다. Push Mode 의 응답은 제외한다.");

			ttHint.SetToolTip (rbOffsetDisable, "Offset 적용 안한다.");
			ttHint.SetToolTip (tgsRefVal, "설정된 기준값으로 각 Pixel 에 Offset 을 적용 한다.");
			ttHint.SetToolTip (rbDark_X_Offset, "Dark Pixel 을 X 좌표를 기준으로 Offset 을 적용 한다. (Offset 좌표 X : 0 ~ 80)");
			ttHint.SetToolTip (rbDark_Y_Offset, "Dark Pixel 을 Y 좌표를 기준으로 Offset 을 적용 한다. (Offset 좌표 Y : 0 ~ 59)");
			ttHint.SetToolTip (rbAvrOffset, "Measure Cnt 에 설정된 횟 수 만큰 각 Pixel 별로 Average 를 만들어 Offset 을 적용한다.");

			ttHint.SetToolTip (btnPixelChartShow, "Chart 화면을 보여준다.");
			ttHint.SetToolTip (btnChartClear, "Chart 화면을 Clear 한다.");
			ttHint.SetToolTip (rbSetPixel1, "Chart 1 의 Pixel 정보를 선택 한다. (Image 화면을 마우스로 클릭하여 선택)");
			ttHint.SetToolTip (rbSetPixel2, "Chart 2 의 Pixel 정보를 선택 한다. (Image 화면을 마우스로 클릭하여 선택)");
			ttHint.SetToolTip (rbSetPixel3, "Chart 3 의 Pixel 정보를 선택 한다. (Image 화면을 마우스로 클릭하여 선택)");
			ttHint.SetToolTip (rbSetPixel4, "Chart 4 의 Pixel 정보를 선택 한다. (Image 화면을 마우스로 클릭하여 선택)");
			ttHint.SetToolTip (rbSetPixel5, "Chart 5 의 Pixel 정보를 선택 한다. (Image 화면을 마우스로 클릭하여 선택)");
			ttHint.SetToolTip (nudMaxVal, "Chart 의 Max 범위를 설정 한다.");
			ttHint.SetToolTip (nudMinVal, "Chart 의 Min 범위를 설정 한다.");

			ttHint.SetToolTip (rbSingleOdd, "Odd Image 만 화면에 출력 한다. / Push Mode 일 경우 Odd Image 만 요청하고 화면에 출력 한다.");
			ttHint.SetToolTip (rbSingleEven, "Even Image 만 화면에 출력 한다. / Push Mode 일 경우 Even Image 만 요청하고 화면에 출력 한다.");
			ttHint.SetToolTip (rbOddEvenToggle, "Odd 와 Even Image 를 화면에 출력 / Push Mode 일 경우 Odd 와 Even Image 를 요청하고 화면에 출력 한다.");
			ttHint.SetToolTip (tgsContinue, "연속 또는 1회 만 Read 하는 모드를 설정 한다. (Push Mode 미적용)");
			ttHint.SetToolTip (nudInterval, "연속 Read Interval 시간을 설정 한다.");
			ttHint.SetToolTip (btnGetPixelInfo, "Get Pixel Info 명령을 전송 한다. (Read Start 또는 Stop)");
			ttHint.SetToolTip (nudAvrCnt, "GUI / Move8 Average Count 를 설정 한다.");
			ttHint.SetToolTip (btnReadPushMode, "Get Pixel Info Push-Mode 명령을 전송한다. (Read Push-Mode Start 또는 Stop");
			ttHint.SetToolTip (rbNormal, "Average 기능을 사용하지 않는다.");
			ttHint.SetToolTip (rbFpgaAvr, "Get Pixel Info - Average 명령을 전송 한다. (FPGA 에서 Average 적용)");
			ttHint.SetToolTip (rbGuiAvr, "GUI 에서 Average 를 적용 한다.");
			ttHint.SetToolTip (rbMoveAvr, "GUI 에서 Move Average 를 적용 한다.");
			ttHint.SetToolTip (btnSetReadPLStart, "Pixel Read Start 또는 Stop 명령을 전송 한다. (PL Read Start 또는 Stop, Push-Mode Stop 은 제외)");

			ttHint.SetToolTip (nudRegAddr, "Register Read / Write 명령의 Address 를 설정 한다.");
			ttHint.SetToolTip (tbRegData, "Register Write 의 Data 를 설정 한다.");
			ttHint.SetToolTip (btnRegWrite, "Register Write 명령을 전송 한다.");
			ttHint.SetToolTip (btnRegRead, "Register Read 명령을 전송 한다.");
			ttHint.SetToolTip (btnTas1945RegCtrl, "전체 Register Control Form 을 활성화 한다.");
			ttHint.SetToolTip (btnRegAllRead, "전체 Register 를 Read 한다.");

			ttHint.SetToolTip (rbServer, "GUI Server mode 로 설정 한다.");
			ttHint.SetToolTip (rbClient, "GUI Client mode 로 설정 한다.");
			ttHint.SetToolTip (ipAddress, "접속 할 Device 의 IP 를 설정 한다.");
			ttHint.SetToolTip (nudTcpPort, "접속 할 Device 의 Port 를 설정 한다.");
			ttHint.SetToolTip (tgsNetMode, "TCP / UDP 선택 한다.");
			ttHint.SetToolTip (btnTcpConnect, "TCP 또는 UDP 로 Device 와 연결을 한다.");

			ttHint.SetToolTip (btnImageClear, "Image 화면을 Clear 한다.");
			ttHint.SetToolTip (tgsPixels, "Image Pixel 단위 출력 또는 BitMap 출력을 선택 한다.");
			ttHint.SetToolTip (tgsImageX10, "BitMap 확대 배율을 선택 한다.");
			ttHint.SetToolTip (tgsShowImage, "Image 를 화면에 출력 유무를 선택 한다.");
			ttHint.SetToolTip (lbOdd, "Odd Image 수신 상태 (RED : 수신, BLK : 미수신)");
			ttHint.SetToolTip (lbEven, "Even Image 입력 상태 (RED : 수신, BLK : 미수신)");
			ttHint.SetToolTip (nudPixelSpace, "Pixel Image 의 테두리를 설정 한다.");
			ttHint.SetToolTip (tbPixelX, "Image 의 X 축 좌표를 입력 한다.");
			ttHint.SetToolTip (tbPixelY, "Image 의 Y 축 좌표를 입력 한다.");
			ttHint.SetToolTip (tbPixelValue, "Device 에서 수신된 XY 좌표의 Pixel Data 를 표시 한다.");
			ttHint.SetToolTip (tbPixelOffset, "XY 좌표에 적용된 Offset 을 표시한다.");
			ttHint.SetToolTip (tbPixelRGB, "XY 좌표의 RGB 값을 표시 한다.");
			ttHint.SetToolTip (tgsCsvSave, "CSV File 저장 유무를 선택 한다.");
			ttHint.SetToolTip (nudCsvSaveCnt, "80,0-2-59 Pixel 선택할 시 Pixel 정보를 RAM 에 저장 할 수 있는 최대 카운트를 설정한다.");
			ttHint.SetToolTip (rbTestPixel, "80,0-2-59 Pixel 선택 시에는 Pixel 정보를 RAM 에 저장 후 Stop 할 시에 CSV File 에 한 번에 기록한다.");
			ttHint.SetToolTip (tgsDebugLog, "LOG Display 유무를 선택 한다.");
			ttHint.SetToolTip (tgsChartLog, "Color 값 Display 유무를 선택 한다.");
			ttHint.SetToolTip (btnLogClear, "LOG 화면의 정보를 Clear 한다.");

			ttHint.SetToolTip (nudPixelMeasure, "Offset 을 적용을 위한 각 Pixel 의 값을 측정하는 Count 값을 설정 한다.");			
		}
	}
}
