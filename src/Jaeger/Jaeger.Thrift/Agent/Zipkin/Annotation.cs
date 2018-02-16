/**
 * Autogenerated by Thrift Compiler (0.11.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Collections;

using Thrift.Protocols;
using Thrift.Protocols.Entities;
using Thrift.Protocols.Utilities;
using Thrift.Transports;
using Thrift.Transports.Client;
using Thrift.Transports.Server;


namespace Jaeger.Thrift.Agent.Zipkin
{

  /// <summary>
  /// An annotation is similar to a log statement. It includes a host field which
  /// allows these events to be attributed properly, and also aggregatable.
  /// </summary>
  public partial class Annotation : TBase
  {
    private long _timestamp;
    private string _value;
    private Endpoint _host;

    /// <summary>
    /// Microseconds from epoch.
    /// 
    /// This value should use the most precise value possible. For example,
    /// gettimeofday or syncing nanoTime against a tick of currentTimeMillis.
    /// </summary>
    public long Timestamp
    {
      get
      {
        return _timestamp;
      }
      set
      {
        __isset.timestamp = true;
        this._timestamp = value;
      }
    }

    public string Value
    {
      get
      {
        return _value;
      }
      set
      {
        __isset.@value = true;
        this._value = value;
      }
    }

    /// <summary>
    /// Always the host that recorded the event. By specifying the host you allow
    /// rollup of all events (such as client requests to a service) by IP address.
    /// </summary>
    public Endpoint Host
    {
      get
      {
        return _host;
      }
      set
      {
        __isset.host = true;
        this._host = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool timestamp;
      public bool @value;
      public bool host;
    }

    public Annotation()
    {
    }

    public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I64)
              {
                Timestamp = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                Value = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.Struct)
              {
                Host = new Endpoint();
                await Host.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default: 
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var struc = new TStruct("Annotation");
        await oprot.WriteStructBeginAsync(struc, cancellationToken);
        var field = new TField();
        if (__isset.timestamp)
        {
          field.Name = "timestamp";
          field.Type = TType.I64;
          field.ID = 1;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteI64Async(Timestamp, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (Value != null && __isset.@value)
        {
          field.Name = "value";
          field.Type = TType.String;
          field.ID = 2;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await oprot.WriteStringAsync(Value, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (Host != null && __isset.host)
        {
          field.Name = "host";
          field.Type = TType.Struct;
          field.ID = 3;
          await oprot.WriteFieldBeginAsync(field, cancellationToken);
          await Host.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString()
    {
      var sb = new StringBuilder("Annotation(");
      bool __first = true;
      if (__isset.timestamp)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("Timestamp: ");
        sb.Append(Timestamp);
      }
      if (Value != null && __isset.@value)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("Value: ");
        sb.Append(Value);
      }
      if (Host != null && __isset.host)
      {
        if(!__first) { sb.Append(", "); }
        __first = false;
        sb.Append("Host: ");
        sb.Append(Host== null ? "<null>" : Host.ToString());
      }
      sb.Append(")");
      return sb.ToString();
    }
  }

}