using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

public class WebClientEx : WebClient
{
	private HttpWebRequest _request = null;

	private bool _AllowAutoRedirect = false;
	public bool AllowAutoRedirect
	{
		get { return _AllowAutoRedirect; }
		set { _AllowAutoRedirect = value; }
	}

	private TimeSpan _timeout = new TimeSpan(0, 0, 8);
	public TimeSpan Timeout { get { return _timeout; } set { _timeout = value; } }

	private TimeSpan _readWriteTimeout = new TimeSpan(0, 0, 25);
	public TimeSpan ReadWriteTimeout { get { return _readWriteTimeout; } set { _readWriteTimeout = value; } }

	private bool _headMethod = false;
	private bool HeadMethod
	{
		get
		{
			bool value = _headMethod;
			_headMethod = false;
			return value;
		}
	}

	protected override WebRequest GetWebRequest(Uri address)
	{
		//var request = (HttpWebRequest)base.GetWebRequest(address);
		//request.AllowAutoRedirect = _AllowAutoRedirect;
		//return request;

		_request = (HttpWebRequest)base.GetWebRequest(address);
		_request.AllowAutoRedirect = _AllowAutoRedirect;
		_request.Timeout = (int)_timeout.TotalMilliseconds;
		_request.ReadWriteTimeout = (int)_readWriteTimeout.TotalMilliseconds;

		if (HeadMethod)
			_request.Method = "HEAD";

		return _request;
	}

	private HttpWebResponse GetLastWebResponse()
	{
		return _request != null && base.GetWebResponse(_request) != null ?
			(HttpWebResponse)base.GetWebResponse(_request) : null;
	}

	public int? LastHttpCode
	{
		get
		{
			var response = GetLastWebResponse();
			return response != null ? (int?)response.StatusCode : (int?)null;
		}
	}

	public string LastHttpStatus
	{
		get
		{
			var response = GetLastWebResponse();
			return response != null ? response.StatusDescription : null;
		}
	}

	public Version LastProtocolVersion
	{
		get
		{
			var response = GetLastWebResponse();
			return response != null ? response.ProtocolVersion : null;
		}
	}

	private int _tries = 1;
	public WebResponseEx? OpenUrl(string address, string postData = null, string cookies = null, bool headMethod = false)
	{
		try
		{
			base.Headers[HttpRequestHeader.Cookie] = cookies;
			string content = null;
			_headMethod = headMethod;

			if (string.IsNullOrEmpty(postData))
				content = base.DownloadString(address);
			else
			{
				base.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
				content = base.UploadString(address, postData);
				base.Headers.Remove(HttpRequestHeader.ContentType);
			}

			return new WebResponseEx(
				this.LastProtocolVersion,
				this.LastHttpCode.Value,
				this.LastHttpStatus,
				base.ResponseHeaders,
				address,
				content
			);
		}
		catch
		{
			return _tries-- >= 0 ? OpenUrl(address, postData, cookies, headMethod) : null;
		}
	}

	public WebResponseEx? OpenUrl(Uri address, string postData = null, string cookies = null, bool headMethod = false)
	{
		try
		{
			return OpenUrl(address.ToString(), postData, cookies, headMethod);
		}
		catch { return null; }
	}
}

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
