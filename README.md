This repository was created to first meet the instructions provided below. It is becoming a place to prototype concepts and technologies for purposes of training and learning.

#Coding Katas
A code kata is an exercise in programming which helps a programmer hone their skills through practice and repetition. The term was probably first coined by Dave Thomas, co-author of the book The Pragmatic Programmer, in a bow to the Japanese concept of kata in the martial arts. As of October 2011, Dave Thomas has published 21 different katas.

ref: https://en.wikipedia.org/wiki/Kata_(programming)  

##Sales Tax Calculation
Basic sales tax is applicable at a rate of 10% on all goods, except books, food, and medical products, which are exempt. Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions. 

A receipt is produced for each purchased item listing the name of the items and the price, including the tax. The receipt also shows the total for all items purchased and the total sales tax paid.  The rounding rules for sales tax are for a tax rate of n%, a shelf price of p contains (np/100 rounded up to the nearest 0.05) amount of sales tax. 

Write an application that takes input for shopping baskets and returns receipts in the format shown below. 


###Scenario 1 
> 1 book at 12.49  
> 1 book at 12.49  
> 1 music CD at 14.99  
> 1 chocolate bar at 0.85 
> _____________________ 
> #### Output 1:  
> Book: 24.98 (2 @ 12.49)  
> Music CD: 16.49  
> Chocolate bar: 0.85  
> Sales Taxes: 1.50  
> Total: 42.32  


###Scenario 2
> 1 imported box of chocolates at 10.00  
> 1 imported bottle of perfume at 47.50  
> _____________________  
> #### Output 2: 
> Imported box of chocolates: 10.50  
> Imported bottle of perfume: 54.65  
> Sales Taxes: 7.65  
> Total: 65.15  
 

###Scenario 3
> 1 imported bottle of perfume at 27.99 
> 1 bottle of perfume at 18.99  
> 1 packet of headache pills at 9.75  
> 1 box of imported chocolates at 11.25  
> 1 box of imported chocolates at 11.25  
> _____________________  
> #### Output 3:  
> Imported bottle of perfume: 32.19  
> Bottle of perfume: 20.89  
> Packet of headache pills: 9.75  
> Imported box of chocolates: 23.70 (2 @ 11.85) 
> Sales Taxes: 7.30 
> Total: 86.53 

##Links
- http://codekata.com/
- http://www.codekatas.org/
- http://butunclebob.com/ArticleS.UncleBob.TheProgrammingDojo
- https://solidsoft.files.wordpress.com/2011/11/solid-introduction-posters-2-0-0.pdf