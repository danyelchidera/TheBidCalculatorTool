# TheBidCalculatorTool

# Overview
This application allows buyers to calculate the total price of a vehicle (either common or luxury) at a car auction. The total price includes the vehicle base price and various fees based on the vehicle price and type. The application dynamically computes these fees and updates the total cost in real-time as the base price or vehicle type changes.

# Features
Input field to enter the vehicle base price.
Dropdown to specify the vehicle type (Common or Luxury).
Display of the list of fees and their amounts.
Automatic computation and display of the total cost whenever the price or type changes.
Fixed and Variable Costs
Basic Buyer Fee:

# Common:
10% of the vehicle price.
Minimum: $10
Maximum: $50
Luxury:
10% of the vehicle price.
Minimum: $25
Maximum: $200
Seller's Special Fee:

Common: 2% of the vehicle price.
Luxury: 4% of the vehicle price.
Association Fee:

$5 for an amount between $1 and $500.
$10 for an amount greater than $500 up to $1000.
$15 for an amount greater than $1000 up to $3000.
$20 for an amount over $3000.
Storage Fee: A fixed fee of $100.

# Example Calculation
For a vehicle priced at $1000 (Common):

Basic buyer fee: $50 (10%, minimum: $10, maximum: $50)
Special fee: $20 (2%)
Association fee: $10
Storage fee: $100
Total: $1180 = $1000 + $50 + $20 + $10 + $100

# Usage
Enter the vehicle base price in the input field.
Select the vehicle type (Common or Luxury) from the dropdown.
View the list of fees and their amounts displayed below the form.
The total cost will be automatically computed and displayed every time the price or type changes.
