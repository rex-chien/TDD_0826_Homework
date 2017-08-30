# TDD_0826_Homework

### Scenario 1
    Given 第一集買了 1 本
	And 第二集買了 0 本
	And 第三集買了 0 本
	And 第四集買了 0 本
	And 第五集買了 0 本
	When 結帳
	Then 價格應為 100 元
	
### Scenario 2
    Given 第一集買了 1 本
	And 第二集買了 1 本
	And 第三集買了 0 本
	And 第四集買了 0 本
	And 第五集買了 0 本
	When 結帳
	Then 價格應為 190 元
	
### Scenario 3
    Given 第一集買了 1 本
	And 第二集買了 1 本
	And 第三集買了 1 本
	And 第四集買了 0 本
	And 第五集買了 0 本
	When 結帳
	Then 價格應為 270 元

### Scenario 4
    Given 第一集買了 1 本
	And 第二集買了 1 本
	And 第三集買了 1 本
	And 第四集買了 1 本
	And 第五集買了 0 本
	When 結帳
	Then 價格應為 320 元
	
### Scenario 5
    Given 第一集買了 1 本
	And 第二集買了 1 本
	And 第三集買了 1 本
	And 第四集買了 1 本
	And 第五集買了 1 本
	When 結帳
	Then 價格應為 375 元
	
### Scenario 6
    Given 第一集買了 1 本
	And 第二集買了 1 本
	And 第三集買了 2 本
	And 第四集買了 0 本
	And 第五集買了 0 本
	When 結帳
	Then 價格應為 370 元

### Scenario 7
    Given 第一集買了 1 本
	And 第二集買了 2 本
	And 第三集買了 2 本
	And 第四集買了 0 本
	And 第五集買了 0 本
	When 結帳
	Then 價格應為 460 元
	
### Scenario 8
    Given 第一集買了 2 本
	And 第二集買了 2 本
	And 第三集買了 2 本
	And 第四集買了 1 本
	And 第五集買了 1 本
	When 結帳
	Then 價格應為 4本+4本=640 元	
	
### Scenario 9
    Given 第一集買了 2 本
	And 第二集買了 2 本
	And 第三集買了 2 本
	And 第四集買了 2 本
	And 第五集買了 1 本
	When 結帳
	Then 價格應為 5本+4本 = 695 元		
	
### Scenario 10
	Given 第一集買了 4 本
	And 第二集買了 4 本
	And 第三集買了 4 本
	And 第四集買了 2 本
	And 第五集買了 2 本
	When 結帳
	Then 價格應為 640*2=1280 元