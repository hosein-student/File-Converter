// using FileConverter.Application.Common.Errors;
// using Newtonsoft.Json.Linq;
//
// namespace FileConverter.Application.Common.Results
// {
//     //Generic
//     public sealed class Result<T>
//     {
//         public T? Value { get; }
//         public Error Error { get; }
//         public bool IsSuccess => Error == Error.None;
//         public bool IsFailure => !IsSuccess;
//
//         private Result(T value) { Value = value; Error = Error.None; }
//         private Result(Error error) { Value = default; Error = error; }
//
//         public static Result<T> Success(T value) => new(value);
//         public static Result<T> Failure(Error error) => new(error);
//     }
//
//     // Non-generic
//     public sealed class Result
//     {
//         public Error Error { get; }
//         public bool IsSuccess => Error == Error.None;
//         public bool IsFailure => !IsSuccess;
//
//         private Result() { Error = Error.None; }
//         private Result(Error error) { Error = error; }
//
//         public static Result Success() => new();
//         public static Result Failure(Error error) => new(error);
//     }
// }