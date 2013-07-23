using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

public struct WebResponseEx
{
	private Version _protocolVersion;
	private int _httpCode;
	private string _httpStatus;
	private WebHeaderCollection _headersCollection;
	private string _address;
	//Private _uri As Uri
	private string _htmlTitle;

	private string _content;
	public Version ProtocolVersion
	{ get {
		return _protocolVersion;
	} }

	public int HttpCode
	{ get {
		return _httpCode;
	} }

	public string OriginalAddress
	{ get {
		return _address;
	} }

	public string HttpStatus
	{
		get { return _httpStatus; }
	}

	public WebHeaderCollection HeadersCollection
	{
		get { return _headersCollection; }
	}

	public string Headers
	{
		get { return HeadersCollection.ToString(); }
	}

	public string FullHeaders
	{
		get { return "HTTP/" + ProtocolVersion.ToString() + " " + HttpCode.ToString() + " " + HttpStatus + "\r\n" + Headers; }
	}

	public Uri Uri
	{
		get { return new Uri(_address); }
	}

	public string HtmlTitle
	{
		get { return _htmlTitle; }
	}

	public string Content
	{
		get { return _content; }
	}

	public string FullResponse
	{
		get { return FullHeaders + Content; }
	}

	public WebResponseEx(Version protocolVersion, int httpCode, string httpStatus, WebHeaderCollection headersCollection, string address, string content)
	{
		_protocolVersion = protocolVersion;
		_httpCode = httpCode;
		_httpStatus = httpStatus;
		_headersCollection = headersCollection;
		_address = address;
		_content = content;

		if (Regex.IsMatch(content, "(?i)<title>[^<]+</title>"))
		{
			_htmlTitle = Regex.Match(content, "(?i)<title>([^<]+)</title>").Groups[1].Value;
		}
		else if (!string.IsNullOrEmpty(content))
		{
			_htmlTitle = content.Substring(0, Math.Min(100, content.Length)).Replace("\r", " ").Replace("\n", " ");
		}
		else _htmlTitle = "";

		_htmlTitle = WebUtility.HtmlDecode(_htmlTitle);
	}
}
