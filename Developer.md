Important notes for running the application:
1. Zip.InstallmentsService is developed using .Net 6.0.
2. Please download and install .Net 6.0 SDk into your system.
3. Open the Solution in Visual Studio 2019 or later.
4. Run the Zip.InstallmentsService project
5. Go to url http://localhost:8083/swagger/index.html from your browser
6. Swagger UI will display the API available in this project

API Information:
1. Created the below API to generate the payment plan:

api/installment/generatepaymentplan

2. This is a HttpPost request. Following values needs to be passed from RequestBody during post api call:
{
  "purchaseAmount": 500,
  "noOfInstallments": 4,
  "frequency": 14
}
PurchaseAmount ==> The total amount for which installment plan needs to be generated.
NoOfInstallments ==> No. of Installments the customer is opting for. Must be greater than 1.
Frequency ==> Interval in no. of days which the customer needs to pay the installments. Must Be greater than 1.

3. Below is the response user will get on successfull execution:

{
  "id": "068cdef7-ed18-4789-9936-50e50a9aaca2",
  "purchaseAmount": 500,
  "installments": [
    {
      "id": "7c7e9b0f-bf2c-402f-ab53-3e6b475a19c0",
      "dueDate": "2022-10-20T00:00:00Z",
      "amount": 125
    },
    {
      "id": "5637e0e7-8b0d-49ed-9fb2-09792f27d26a",
      "dueDate": "2022-11-03T00:00:00Z",
      "amount": 125
    },
    {
      "id": "976305ab-d359-4576-a536-2f56d6551cec",
      "dueDate": "2022-11-17T00:00:00Z",
      "amount": 125
    },
    {
      "id": "3ba25cff-6ffd-40c9-9e02-ba3e0149e2ab",
      "dueDate": "2022-12-01T00:00:00Z",
      "amount": 125
    }
  ]
}