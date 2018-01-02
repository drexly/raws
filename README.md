# raws
Read And Write english words Software: 통합영단어학습프로그램

Integrated English Learning Software for Windows Supporting Transparent UI mode Overlaying English Reading Contents

Developed In C# WinForms on VS2014

### Summerization

1.단어 입력 및 실시간 저장(Enter Key로 손쉽게 다음항목 focus 가능) 기본 입력 포맷: 영단어,한글 뜻, 유의어 반의어 및 부가설명(옵션 항목)

![https://github.com/drexly/raws](/intro/a.png?raw=true "엔터키 만으로 다음 필드 순차 입력")

2.단어 슬라이드 쇼(언제 학습했는지 캘린더 UI 통해서 확인 가능, 순차, 랜덤, 범위지정 가능)

3.단어 테스트 (4지선다 랜덤 순서 보기 출력 및 정오여부 실시간 확인 가능)

4.오답노트 기입(오답 단어들만 추후 테스트 가능)

![https://github.com/drexly/raws](/intro/b.png?raw=true "maximized UI")

### Details

개인 영단어-숙어 학습 생산성 향상을 위해 만든 학습 플랫폼으로 컴퓨터에서 영문 독해 시 모르는 새로운 어구를 학습할 때 

엔터키로 쉽게 저장하고, 슬라이드 쇼로 재생해 머릿속에 복기하며 다른 단어들과 4지선다 시험을 보고, 

시험 볼때 틀린 단어는 정답을 알려주며 wrong.log 의 오답노트로 자동 저장해 따로 재시험을 볼 수 있는 시스템

 Calendar를 통해 일자별 학습한 단어 결과들을 볼 수 있고, 학습을 위한 단어 Selection은 Select/Deselect ALL,
 
 Invert Selection, Random Selection(다이얼로 선택할 단어 수 변경 가능) 가능함

슬라이드 학습 및 테스트도 랜덤/순차, 자동전환/수동전환 선택 가능

단어 기입 및 삭제, 새로고침, 새로운 리스트 불러오기 가능. 테스트 모드에서 단어 선택 없이 엔터만 누를시 랜덤 테스트

![https://github.com/drexly/raws](/intro/c.png?raw=true "Initialized overall")

### Function Keys in Use: 

#### General Function Key
F1- 앱 투명도 증가  F2- 앱 투명도 감소

#### Learn Selection, Slide Selection,
F3- 이전 단어 슬라이드 F4- 다음 단어 슬라이드

#### Rotate All Items
F5- 단어 슬라이드쇼 재생/일시정지
F6- 단어 슬라이드쇼 모드 순차/랜덤
F7- 단어장 랜덤 점프

#### Test Selection
Click & Enter to submit answer

![https://github.com/drexly/raws](/intro/d.png?raw=true "Initialized overall")




