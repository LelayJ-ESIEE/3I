package com.dma.modele.dao;

import java.io.Serializable;

public class AgendaException extends RuntimeException implements Serializable {

  private static final long serialVersionUID = 1L;
  // champs privés
  private int code = 0;

  // constructeurs
  public AgendaException() {
    super();
  }

  public AgendaException(String message) {
    super(message);
  }

  public AgendaException(String message, Throwable cause) {
    super(message, cause);
  }

  public AgendaException(Throwable cause) {
    super(cause);
  }

  public AgendaException(String message, int code) {
    super(message);
    setCode(code);
  }

  public AgendaException(Throwable cause, int code) {
    super(cause);
    setCode(code);
  }

  public AgendaException(String message, Throwable cause, int code) {
    super(message, cause);
    setCode(code);
  }

  // getters - setters
  public int getCode() {
    return code;
  }

  public void setCode(int code) {
    this.code = code;
  }
}
