namespace Fable.Import

open System
open Fable.Core
open Fable.Import.JS

/// Fable bindings for Axios
///
/// For usage instructions refer to the Axios docs at https://github.com/axios/axios
module Axios =
    type AxiosHttpBasicAuth =
        abstract username : string with get, set
        abstract password : string with get, set

    and AxiosXHRConfigBase<'T> =
        abstract baseURL : string option with get, set
        abstract headers : obj option with get, set
        abstract ``params`` : obj option with get, set
        abstract paramsSerializer : Func<obj, string> option with get, set
        abstract timeout : float option with get, set
        abstract withCredentials : bool option with get, set
        abstract auth : AxiosHttpBasicAuth option with get, set
        abstract responseType : string option with get, set
        abstract xsrfCookieName : string option with get, set
        abstract xsrfHeaderName : string option with get, set
        abstract transformRequest : U2<Func<'T, 'U>, Func<'T, 'U>> option with get, set
        abstract transformResponse : Func<'T, 'U> option with get, set

    and AxiosXHRConfig<'T> =
        inherit AxiosXHRConfigBase<'T>
        abstract url : string with get, set
        abstract method : string option with get, set
        abstract data : 'T option with get, set

    and AxiosXHR<'T> =
        abstract data : 'T with get, set
        abstract status : int with get, set
        abstract statusText : string with get, set
        abstract headers : obj with get, set
        abstract config : AxiosXHRConfig<'T> with get, set

    and Interceptor =
        abstract request : RequestInterceptor with get, set
        abstract response : ResponseInterceptor with get, set

    and InterceptorId =
        float

    and RequestInterceptor =
        abstract ``use`` : fulfilledFn:Func<AxiosXHRConfig<'U>, AxiosXHRConfig<'U>> -> InterceptorId
        abstract ``use`` : fulfilledFn:Func<AxiosXHRConfig<'U>, AxiosXHRConfig<'U>> * rejectedFn:Func<obj, obj> -> InterceptorId
        abstract eject : interceptorId:InterceptorId -> unit

    and ResponseInterceptor =
        abstract ``use`` : fulfilledFn:Func<AxiosXHR<'T>, AxiosXHR<'T>> -> InterceptorId
        abstract ``use`` : fulfilledFn:Func<AxiosXHR<'T>, AxiosXHR<'T>> * rejectedFn:Func<obj, obj> -> InterceptorId
        abstract eject : interceptorId:InterceptorId -> unit

    and AxiosInstance =
        abstract interceptors : Interceptor with get, set
        [<Emit("$0($1...)")>] abstract Invoke : config:AxiosXHRConfig<'T> -> Promise<AxiosXHR<'T>>
        [<Emit("new $0($1...)")>] abstract Create : config:AxiosXHRConfig<'T> -> Promise<AxiosXHR<'T>>
        abstract request : config:AxiosXHRConfig<'T> -> Promise<AxiosXHR<'T>>
        abstract all : values:U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> * U2<'T6, Promise<AxiosXHR<'T6>>> * U2<'T7, Promise<AxiosXHR<'T7>>> * U2<'T8, Promise<AxiosXHR<'T8>>> * U2<'T9, Promise<AxiosXHR<'T9>>> * U2<'T10, Promise<AxiosXHR<'T10>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5> * AxiosXHR<'T6> * AxiosXHR<'T7> * AxiosXHR<'T8> * AxiosXHR<'T9> * AxiosXHR<'T10>>
        abstract all : values:U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> * U2<'T6, Promise<AxiosXHR<'T6>>> * U2<'T7, Promise<AxiosXHR<'T7>>> * U2<'T8, Promise<AxiosXHR<'T8>>> * U2<'T9, Promise<AxiosXHR<'T9>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5> * AxiosXHR<'T6> * AxiosXHR<'T7> * AxiosXHR<'T8> * AxiosXHR<'T9>>
        abstract all : values:U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> * U2<'T6, Promise<AxiosXHR<'T6>>> * U2<'T7, Promise<AxiosXHR<'T7>>> * U2<'T8, Promise<AxiosXHR<'T8>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5> * AxiosXHR<'T6> * AxiosXHR<'T7> * AxiosXHR<'T8>>
        abstract all : values:U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> * U2<'T6, Promise<AxiosXHR<'T6>>> * U2<'T7, Promise<AxiosXHR<'T7>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5> * AxiosXHR<'T6> * AxiosXHR<'T7>>
        abstract all : values:U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> * U2<'T6, Promise<AxiosXHR<'T6>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5> * AxiosXHR<'T6>>
        abstract all : values:U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5>>
        abstract all : values:U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4>>
        abstract all : values:U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3>>
        abstract all : values:U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2>>
        abstract spread : fn:Func<'T1, 'T2, 'U> -> Func<'T1 * 'T2, 'U>
        abstract get : url:string * ?config:AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>
        abstract delete : url:string * ?config:AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>
        abstract head : url:string * ?config:AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>
        abstract post : url:string * ?data:obj * ?config:AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>
        abstract put : url:string * ?data:obj * ?config:AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>
        abstract patch : url:string * ?data:obj * ?config:AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>

    and AxiosStatic =
        inherit AxiosInstance
        abstract create : config:AxiosXHRConfigBase<'T> -> AxiosInstance

    //
    // Error handling
    //

    /// The error object returned by axios to the catch of a failed request promise.
    /// See https://github.com/axios/axios/blob/master/lib/core/enhanceError.js
    and private AxiosErrorJS<'T, 'E> =
        /// Exception name
        abstract member name : string
        /// Exception message
        abstract member message : string
        /// The config for the axios request that caused the error
        abstract member config : AxiosXHRConfigBase<'T>
        /// An instance of XMLHttpRequest, populated if the request was made but no response was received
        abstract member request : obj option
        /// Error response returned by the server
        abstract member response : AxiosXHR<'E> option
    module private AxiosErrorJS =
        /// Downcast the specified javascript error 'obj' to a strongly-typed AxiosErrorJs
        let fromJsNativeObj<'T, 'E> (jsNative : obj) : AxiosErrorJS<'T, 'E> =
             downcast jsNative

    /// The request was sent and the server responded with a status code outside of the 2xx range.
    type AxiosErrorResponse<'T, 'E> =
        { name : string
          message : string
          config : AxiosXHRConfigBase<'T>
          request : obj
          response : AxiosXHR<'E> }

    /// The request was made but no response was received.
    type AxiosNoResponse<'T> =
        { name : string
          message : string
          config : AxiosXHRConfigBase<'T>
          request : obj }

    /// An error occurred while setting up the request
    type AxiosRequestFailed<'T> =
        { name : string
          message : string
          config : AxiosXHRConfigBase<'T> }

    /// <summary>
    /// The three types of errors that can occur when making an axios request.
    /// See: https://github.com/axios/axios#handling-errors
    /// </summary>
    ///
    /// <typeparam name="T">Content data type for a successful response.</typeparam>
    /// <typeparam name="E">Content data type for an error response.</typeparam>
    type AxiosError<'T, 'E> =
        | ErrorResponse of AxiosErrorResponse<'T, 'E>
        | NoResponse of AxiosNoResponse<'T>
        | RequestFailed of AxiosRequestFailed<'T>
    module AxiosError =
        /// Get the message from the specified error
        let getMessage (error : AxiosError<_,_>) =
            match error with
            | ErrorResponse e ->
                e.message
            | NoResponse e ->
                e.message
            | RequestFailed e ->
                e.message

        /// Convert a jsNative error 'obj' returned by axios to a strontly-typed AxiosError
        let fromNativeJsObj (jsNative : obj) : AxiosError<'T, 'E> =
            let error = AxiosErrorJS.fromJsNativeObj jsNative
            match error.response, error.request with
            | Some response, Some request ->
                ErrorResponse
                    { name = error.name
                      message = error.message
                      config = error.config
                      request = request
                      response = response }
            | _ , Some request ->
                NoResponse
                    { name = error.name
                      message = error.message
                      config = error.config
                      request = request }
            | _ ->
                RequestFailed
                    { name = error.name
                      message = error.message
                      config = error.config }

    /// Axios-specific extensions to Fable.Powerpack.Promise.
    module Promise =
        let private handleAxiosError (fail : AxiosError<'T, 'E> -> 'R) (jsError : System.Exception) : 'R =
              fail <| AxiosError.fromNativeJsObj jsError

        /// <summary>
        /// JS.Promise catch function, allowing the user to provide an error handling function
        /// that accepts a strongly typed <c>AxiosError</c>.
        /// </summary>
        ///
        /// <param name="fail">Error handling function.</param>
        /// <param name="">The promise for which to apply the error handling function.</param>
        let catchAxios (fail : AxiosError<'T, 'E> -> 'R) (promise : JS.Promise<'R>) : JS.Promise<'R> =
            promise
            |> Fable.PowerPack.Promise.catch (handleAxiosError fail)

module Globals =
    /// import axios from 'axios'
    [<Import("default", from="axios")>]
    let axios : Axios.AxiosStatic = jsNative
