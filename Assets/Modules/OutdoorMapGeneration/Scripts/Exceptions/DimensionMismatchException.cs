
using UnityEngine;
using System;

[System.Serializable]
public class DimensionMismatchException : System.Exception
{
	public DimensionMismatchException() {
        Debug.LogError("DimensionMismatchException: mismatch in array dimensions");
    }
	 
	 
	public DimensionMismatchException( string message ) : base( message ) {
		Debug.LogError("DimensionMismatchException: " + message);
	 }
	 
	 public DimensionMismatchException( object array ) {
		Debug.LogError("DimensionMismatchException: occured with " + array.ToString() + " object" );
	 }
	 
	 public DimensionMismatchException( string message, object array ) : base( message ) {
		Debug.LogError("DimensionMismatchException: " + message);
	 }
	 
	 
	public DimensionMismatchException( string message, System.Exception inner ) : base( message, inner ) {
		Debug.LogError("DimensionMismatchException: " + message);
        throw inner;
    }
	 
	protected DimensionMismatchException(
		System.Runtime.Serialization.SerializationInfo info,
		System.Runtime.Serialization.StreamingContext context ) : base( info, context ) {
				
		 }
}