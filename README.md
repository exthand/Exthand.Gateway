# Exthand.Gateway
Client library to use Exthand:Gateway and connect to +1300 banks worldwide.

## How to get started.

Company website: https://www.exthand.com
Nuget Paackage of this repo: https://www.nuget.org/packages/Exthand.Gateway

### 1. Create first an account.

Go to  https://developer.bankingsdk.com and register your self and your company.
Create an application, get the application key and secret.
Store the secret in a safe place.
Send us ( support at exthand.com) your application key and company key. We'll provide you a license key.

You'll be able from there to debug in real time your sandbox calls to get bank statements or initiate payments.
In the documentation part of the website, you'll find the latest PDF Documentation file, read it carefully and mainly chapter 6.


### 2. BankingSDK Docker.

To use Exthand:Gateway to connect to banks, you also have to install a Docker container in your own cloud infrastrucutre.
Docker container might be found here: https://hub.docker.com/r/bankingsdk/bankingsdkdockerapi/tags?page=1&ordering=last_updated

You install it first (check PDF Documentation file).
Then, use this nuget to call the Docker and get access to bank APIs.


### 3. The global flow.

Your app using this package will be able to call API of your BankingSDK Docker.
Your BankingSDK Docker instance will call the Exthand:Gateway API and transfer your requests to the banks.
Banks does answer to the Exthand:Gateway which sends back the response to your Docker.
As simple as that!

The day you get your own open banking license, you have to change the configuration file the BankingSDK Docker.
It will then be able to directly connect to banks without going throught the Exthand:Gateway anymore.


## How to start using the Exthand:Gateway with this nuget package.

### 1. Register a user.

Before being able to get transactions or initiate payement, you have to send to the Exthand:Gateway (E:G) information about the your user (PSU).
For PIS, an email address or cell phone number is sufficient.
For AIS, we require first name, last name, date of birth, email address and version of the Terms and Conditions accepted by the PSU.

#### Call GetTCAsync (AIS only)

Retrieves the latest version of the Terms and Conditions and Privacy Notice.
If doing AIS, you have to show or provide a link those two files, and collect the consent (click on checkbox). The consent means: Me, as a PSU, I accept Exthand shares my banking data with __your company__.
If doing PIS, forget this, consent is not required.

Once you get the consent of the PSU, you have to register him on E:G.

#### Call CreateUserAsync

See above to know how much data you have to provide to this method.
This will return a [UserRegisterResponse](https://github.com/exthand/Exthand.Gateway/blob/master/Models/UserRegisterResponse.cs) object.
Normal case, action property should be == "OK", then you have to store the userContext property with your PSU data.
You will need userContext for all operations, it's __important__ to store it attached to your user and be able to provide it to E/G.




