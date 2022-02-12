# Node chạy python 3.9
# import the necessary packages
from imutils.video import VideoStream
from imutils.video import FPS
import numpy as np
import argparse
import imutils
import time
import cv2

# construct the argument parse and parse the arguments
#xây dựng phân tích cú pháp đối số và phân tích cú pháp đối số
ap = argparse.ArgumentParser()
ap.add_argument("-p", "--prototxt", required=True,
	help="path to Caffe 'deploy' prototxt file")
ap.add_argument("-m", "--model", required=True,
	help="path to Caffe pre-trained model")
ap.add_argument("-c", "--confidence", type=float, default=0.2,
	help="minimum probability to filter weak detections")
args = vars(ap.parse_args())

# initialize the list of class labels MobileNet SSD was trained to
#khởi tạo danh sách nhãn lớp
# detect, then generate a set of bounding box colors for each class
#phát hiện, sau đó tạo một tập hợp các màu hộp giới hạn cho mỗi lớp
CLASSES = ["background", "aeroplane", "bicycle", "bird", "boat",
	"bottle","phone" "bus", "car", "cat", "chair", "cow", "diningtable",
	"dog", "horse", "motorbike", "person", "pottedplant", "sheep",
	"sofa", "train", "tvmonitor"]
COLORS = np.random.uniform(0, 255, size=(len(CLASSES), 3))

# load our serialized model from disk
#tải mô hình tuần tự của chúng tôi từ đĩa
print("[INFO] loading model...")
net = cv2.dnn.readNetFromCaffe(args["prototxt"], args["model"])

# initialize the video stream, allow the cammera sensor to warmup,
##khởi tạo luồng video, cho phép cảm biến máy ảnh nóng lên
# and initialize the FPS counter
#và khởi tạo bộ đếm FPS
print("[INFO] starting video stream...")
vs = VideoStream(src=0).start()
time.sleep(2.0)
fps = FPS().start()

# loop over the frames from the video stream
#lặp lại các khung hình từ luồng video
while True:
	# grab the frame from the threaded video stream and resize it
	#lấy khung hình từ luồng video theo chuỗi và thay đổi kích thước
	# to have a maximum width of 400 pixels
	#có chiều rộng tối đa là 400 pixel
	frame = vs.read()
	frame = imutils.resize(frame, width=400)

	# grab the frame dimensions and convert it to a blob
	#lấy kích thước khung và chuyển đổi nó thành một đốm màu
	(h, w) = frame.shape[:2]
	blob = cv2.dnn.blobFromImage(cv2.resize(frame, (300, 300)),
		0.007843, (300, 300), 127.5)

	# pass the blob through the network and obtain the detections and
	#vượt qua đốm màu qua mạng và thu được các phát hiện và phỏng đoán
	# predictions
	net.setInput(blob)
	detections = net.forward()

	# loop over the detections
	#vòng qua các phát hiện
	for i in np.arange(0, detections.shape[2]):
		# extract the confidence (i.e., probability) associated with
		# the prediction
		#trích xuất độ tin cậy (tức là xác suất) được liên kết với Dự đoán
		confidence = detections[0, 0, i, 2]

		# filter out weak detections by ensuring the `confidence` is
		# # greater than the minimum confidence
		#lọc ra các phát hiện yếu bằng cách đảm bảo độ tin cậy là
		#lớn hơn độ tin cậy tối thiểu
		
		if confidence > args["confidence"]:
			# extract the index of the class label from the			
			# `detections`, then compute the (x, y)-coordinates of
			# the bounding box for the object

			#trích xuất chỉ mục của nhãn lớp từ
			#phát hiện`, sau đó tính toán tọa độ (x, y) của
			#hộp giới hạn cho đối tượng

			idx = int(detections[0, 0, i, 1])
			box = detections[0, 0, i, 3:7] * np.array([w, h, w, h])
			(startX, startY, endX, endY) = box.astype("int")

			# draw the prediction on the frame
			#vẽ dự đoán trên khung
			label = "{}: {:.2f}%".format(CLASSES[idx],
				confidence * 100)
			cv2.rectangle(frame, (startX, startY), (endX, endY),
				COLORS[idx], 2)
			y = startY - 15 if startY - 15 > 15 else startY + 15
			cv2.putText(frame, label, (startX, y),
				cv2.FONT_HERSHEY_SIMPLEX, 0.5, COLORS[idx], 2)

	# show the output frame
	#hiển thị khung đầu ra
	cv2.imshow("Frame", frame)
	key = cv2.waitKey(1) & 0xFF

	# if the `q` key was pressed, break from the loop
	#nếu phím `q` được nhấn, hãy ngắt khỏi vòng lặp
	if key == ord("q"):
		break

	# update the FPS counter
	#cập nhật bộ đếm FPS
	fps.update()

# stop the timer and display FPS information
#dừng bộ đếm thời gian và hiển thị thông tin FPS
fps.stop()
print("[INFO] elapsed time: {:.2f}".format(fps.elapsed()))
print("[INFO] approx. FPS: {:.2f}".format(fps.fps()))

# do a bit of cleanup
cv2.destroyAllWindows()
vs.stop()

# Lệnh chạy
# python real_time_object_detection.py --prototxt MobileNetSSD_deploy.prototxt.txt --model MobileNetSSD_deploy.caffemodel
