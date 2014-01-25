Trosi
======

## Introduction ##
Trosi is a simple wrapper for the Microsoft Translator API. It currently only supports the "Translate" method which takes a string to Translate and the language to translate to and from.

To sign up for the Microsoft Translator API (Required to use) visit: http://datamarket.azure.com/dataset/bing/microsofttranslator

More information about the API can be found on MSDN: http://msdn.microsoft.com/en-us/library/dd576287.aspx

## Usage ##
Add the following to your applications configuration file:

	<configSections>
    <section name="trosi" type="Trosi.Configuration.TrosiConfigurationSection, Trosi" />
  </configSections>

And

	<trosi clientId="YOUR-CLIENT-ID" clientSecret="YOUR-CLIENT-SECRET" />

Inputting your Client Id and Secret.

To translate a string, create an instance of the Translator class, and then call Translate e.g.

	var translator = new Translator();
	var result = translator.Translate("Translate", "en", "de");

The first argument is the string to translate, the second is the language to translate from and the third the language to translate too. The languages should be specified in the two character format specified by the Translator API.