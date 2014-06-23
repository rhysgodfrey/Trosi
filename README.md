Trosi
======

[![Build status](https://ci.appveyor.com/api/projects/status/3y027mgcjq07798e)](https://ci.appveyor.com/project/rhysgodfrey/trosi)

## Introduction ##
Trosi is a simple wrapper for the Microsoft Translator API. It currently only supports the "Translate" method which takes a string to Translate and the language to translate to and from.

To sign up for the Microsoft Translator API (Required to use) visit: http://datamarket.azure.com/dataset/bing/microsofttranslator

More information about the API can be found on MSDN: http://msdn.microsoft.com/en-us/library/dd576287.aspx

## Download ##
The latest version of the library can be downloaded from the [Latest Release Page](https://github.com/rhysgodfrey/Trosi/releases/latest).

## Usage ##
Add the following to your applications configuration file:

``
  <configSections>
    <section name="trosi" type="Trosi.Configuration.TrosiConfigurationSection, Trosi" />
  </configSections>
``

And

``
    <trosi clientId="YOUR-CLIENT-ID" clientSecret="YOUR-CLIENT-SECRET" />
``

Inputting your Client Id and Secret.

To translate a string, create an instance of the Translator class, and then call Translate e.g.

	var translator = new Translator();
	var result = translator.Translate("Translate", "en", "de");

The first argument is the string to translate, the second is the language to translate from and the third the language to translate too. The languages should be specified in the two character format specified by the Translator API.

## License ##

This library is released under the *FreeBSD License*, see **LICENSE.txt** for more information. Please fork this repository and create a Pull Request for any useful updates/enhancements.

Blog: http://www.rhysgodfrey.co.uk

Twitter: @rhysgodfrey
