class Logger {
  constructor(log) {
    this._log = log;
  }

  info(message, isServerConnected = false) {
    if (isServerConnected) {
      this._log.info(message);
    }
  }

  warn(message, isServerConnected = false) {
    if (isServerConnected) {
      this._log.warn(message);
    }
  }

  error(message, isServerConnected = false) {
    if (isServerConnected) {
      this._log.error(message);
    }
  }
}

export default Logger;
