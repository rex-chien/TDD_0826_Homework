Feature: PotterShoppingCart
	In order to 提供最便宜的價格給來買書的爸爸媽媽
	As a 佛心的出版社老闆
	I want to 設計一個哈利波特的購物車

Scenario Outline: 每集買不同本數，算價錢
	Given 第一集買了 <ep1-count> 本
	And 第二集買了 <ep2-count> 本
	And 第三集買了 <ep3-count> 本
	And 第四集買了 <ep4-count> 本
	And 第五集買了 <ep5-count> 本
	When 結帳
	Then 價格應為 <total-price> 元
	Examples: 
	| ep1-count | ep2-count | ep3-count | ep4-count | ep5-count | total-price |
	| 0         | 0         | 0         | 0         | 0         | 0           |
	| 1         | 0         | 0         | 0         | 0         | 100         |
	| 1         | 1         | 0         | 0         | 0         | 190         |
	| 1         | 1         | 1         | 0         | 0         | 270         |
	| 1         | 1         | 1         | 1         | 0         | 320         |
	| 1         | 1         | 1         | 1         | 1         | 375         |
	| 1         | 1         | 2         | 0         | 0         | 370         |
	| 1         | 2         | 2         | 0         | 0         | 460         |
	| 2         | 2         | 2         | 1         | 1         | 640         |
	| 2         | 2         | 2         | 2         | 1         | 695         |
	| 4         | 4         | 4         | 2         | 2         | 1280        |
