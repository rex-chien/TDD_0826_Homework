Scenario: 第一集買了一本，其他都沒買，價格應為100*1=100元
	Given 第一集買了 1 本
	And 第二集買了 0 本
	And 第三集買了 0 本
	And 第四集買了 0 本
	And 第五集買了 0 本
	When 結帳
	Then 價格應為 100 元