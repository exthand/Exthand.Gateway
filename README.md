# Exthand.Gateway
Client library to use Exthand:Gateway and connect to +1300 banks worldwide.

## How to get started.

Company website: https://www.exthand.com


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


